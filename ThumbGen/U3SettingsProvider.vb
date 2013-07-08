Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Configuration.Provider
Imports System.Windows.Forms
Imports System.Collections.Specialized
Imports Microsoft.Win32
Imports System.Xml


Public Class U3SettingsProvider
    Inherits SettingsProvider

    Const U3SETTINGSROOT As String = "U3Settings"
    Const U3APPDATAPATH As String = "U3_APP_DATA_PATH"

    Public Overrides Sub Initialize(ByVal name As String, ByVal col As NameValueCollection)
        MyBase.Initialize(Me.ApplicationName, col)
    End Sub

    Public Overrides Property ApplicationName() As String
        Get
            Return Application.ProductName
        End Get
        Set(ByVal value As String)
            'Ignore
        End Set
    End Property

    'SetPropertyValue is invoked when ApplicationSettingsBase.Save is called
    'ASB makes sure to pass each provider only the values marked for that provider
    Public Overrides Sub SetPropertyValues(ByVal context As SettingsContext, ByVal propvals As SettingsPropertyValueCollection)

        'Iterate through the settings to be stored
        'Only IsDirty=true properties should be included in propvals
        For Each propval As SettingsPropertyValue In propvals

            'NOTE: this provider allows setting to both user- and application-scoped
            'settings. The default provider for ApplicationSettingsBase - 
            'LocalFileSettingsProvider - is read-only for application-scoped setting. This 
            'is an example of a policy that a provider may need to enforce for implementation,
            'security or other reasons.

            SetValue(propval)
        Next

        Try
            SettingsXML.Save(IO.Path.Combine(GetU3AppDataPath, Me.ApplicationName & ".xml"))
        Catch ex As Exception
            'Ignore if cant save, device been ejected
        End Try
    End Sub

    Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, ByVal props As SettingsPropertyCollection) As SettingsPropertyValueCollection
        'Create new collection of values
        Dim values As SettingsPropertyValueCollection = New SettingsPropertyValueCollection()

        'Iterate through the settings to be retrieved
        For Each setting As SettingsProperty In props

            Dim value As SettingsPropertyValue = New SettingsPropertyValue(setting)
            value.IsDirty = False
            value.SerializedValue = GetValue(setting)
            values.Add(value)
        Next
        Return values
    End Function


    Private m_SettingsXML As Xml.XmlDocument = Nothing

    Private ReadOnly Property SettingsXML() As Xml.XmlDocument
        Get
            If m_SettingsXML Is Nothing Then
                m_SettingsXML = New Xml.XmlDocument

                Try
                    m_SettingsXML.Load(IO.Path.Combine(GetU3AppDataPath, Me.ApplicationName & ".xml"))
                Catch ex As Exception
                    'Create new documents
                    Dim dec As XmlDeclaration = m_SettingsXML.CreateXmlDeclaration("1.0", "utf-8", String.Empty)
                    m_SettingsXML.AppendChild(dec)

                    Dim nodeRoot As XmlNode
                    'Dim nodeProperty As XmlNode

                    nodeRoot = m_SettingsXML.CreateNode(XmlNodeType.Element, U3SETTINGSROOT, "")
                    m_SettingsXML.AppendChild(nodeRoot)
                End Try
            End If

            Return m_SettingsXML
        End Get
    End Property

    Private Function GetValue(ByVal setting As SettingsProperty) As String
        Dim ret As String = ""

        Try
            If IsRoaming(setting) Then
                ret = SettingsXML.SelectSingleNode(U3SETTINGSROOT & "/" & setting.Name).InnerText
            Else
                ret = SettingsXML.SelectSingleNode(U3SETTINGSROOT & "/" & My.Computer.Name & "/" & setting.Name).InnerText
            End If

        Catch ex As Exception
            ret = setting.DefaultValue.ToString
        End Try


        Return ret
    End Function

    Private Sub SetValue(ByVal propVal As SettingsPropertyValue)

        Dim MachineNode As Xml.XmlElement
        Dim SettingNode As Xml.XmlElement

        Try
            If IsRoaming(propVal.Property) Then
                SettingNode = DirectCast(SettingsXML.SelectSingleNode(U3SETTINGSROOT & "/" & propVal.Name), XmlElement)
            Else
                SettingNode = DirectCast(SettingsXML.SelectSingleNode(U3SETTINGSROOT & "/" & My.Computer.Name & "/" & propVal.Name), XmlElement)
            End If
        Catch ex As Exception
            SettingNode = Nothing
        End Try

        If Not SettingNode Is Nothing Then
            SettingNode.InnerText = propVal.SerializedValue.ToString
        Else
            If IsRoaming(propVal.Property) Then
                SettingNode = SettingsXML.CreateElement(propVal.Name)
                SettingNode.InnerText = propVal.SerializedValue.ToString
                SettingsXML.SelectSingleNode(U3SETTINGSROOT).AppendChild(SettingNode)
            Else
                Try
                    MachineNode = DirectCast(SettingsXML.SelectSingleNode(U3SETTINGSROOT & "/" & My.Computer.Name), XmlElement)
                Catch ex As Exception
                    MachineNode = SettingsXML.CreateElement(My.Computer.Name)
                    SettingsXML.SelectSingleNode(U3SETTINGSROOT).AppendChild(MachineNode)
                End Try

                If MachineNode Is Nothing Then
                    MachineNode = SettingsXML.CreateElement(My.Computer.Name)
                    SettingsXML.SelectSingleNode(U3SETTINGSROOT).AppendChild(MachineNode)
                End If

                SettingNode = SettingsXML.CreateElement(propVal.Name)
                SettingNode.InnerText = propVal.SerializedValue.ToString
                MachineNode.AppendChild(SettingNode)
            End If
        End If
    End Sub

    'Helper method: walks the "attribute bag" for a given property
    'to determine if it is user-scoped or not.
    'Note that this provider does not enforce other rules, such as 
    '  - unknown attributes
    '  - improper attribute combinations (e.g. both user and app - this implementation
    '    would say true for user-scoped regardless of existence of app-scoped)
    Private Function IsUserScoped(ByVal prop As SettingsProperty) As Boolean
        For Each d As DictionaryEntry In prop.Attributes

            Dim a As Attribute = DirectCast(d.Value, Attribute)
            If TypeOf a Is UserScopedSettingAttribute Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function IsRoaming(ByVal prop As SettingsProperty) As Boolean
        For Each d As DictionaryEntry In prop.Attributes
            Dim a As Attribute = DirectCast(d.Value, Attribute)
            If TypeOf a Is System.Configuration.SettingsManageabilityAttribute Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function GetU3AppDataPath() As String
        Try
            Return System.Environment.GetEnvironmentVariable(U3APPDATAPATH)
        Catch
            Return ""
        End Try
    End Function

End Class
