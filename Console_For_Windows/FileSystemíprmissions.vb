Imports System.DirectoryServices.AccountManagement
Imports System.IO
Imports System.Management
Imports System.Security.AccessControl
Imports System.Security.Principal

Public Class FileSystemPermissions
    Public Shared Sub RemoveDirectorySecurity(user As String, dir As DirectoryInfo)
        Dim dSecurity As DirectorySecurity = dir.GetAccessControl()
        Dim t As New System.Security.Principal.NTAccount(user)
        Dim rules = dSecurity.GetAccessRules(True, True, GetType(System.Security.Principal.NTAccount))
        For Each rule As FileSystemAccessRule In rules
            If rule.IdentityReference.ToString.Contains("Felh") Then
                Dim jj As Int16 = 54
                dSecurity.SetAccessRuleProtection(True, False)
                dSecurity.RemoveAccessRule(New FileSystemAccessRule(user, rule.FileSystemRights, rule.AccessControlType))
            End If
        Next

        dir.SetAccessControl(dSecurity)

    End Sub
    Public Shared Sub SetPrivateDIrectory(user As String, dir As DirectoryInfo)
        Dim dacl As System.Security.AccessControl.DirectorySecurity = New System.Security.AccessControl.DirectorySecurity()
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule("User", System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))
        dacl.AddAccessRule(New FileSystemAccessRule("User", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))

        'System.IO.Directory.CreateDirectory("C:\FruitBat", dacl)
        dir.SetAccessControl(dacl)

    End Sub
    Public Shared Sub SetPublicteDirectory(user As String, dir As DirectoryInfo)
        Dim dacl As System.Security.AccessControl.DirectorySecurity = New System.Security.AccessControl.DirectorySecurity()
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.Read, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Allow))
        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))

        dir.SetAccessControl(dacl)
    End Sub
    Public Shared Sub CreatePrivateDIrectory(user As String, dir As DirectoryInfo)
        Dim dacl As System.Security.AccessControl.DirectorySecurity = New System.Security.AccessControl.DirectorySecurity()
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule("User", System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))

        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))
        dacl.AddAccessRule(New FileSystemAccessRule(user, FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))
        '    dacl.AddAccessRule(New FileSystemAccessRule("User", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))


        dir.Create(dacl)
    End Sub
    Public Shared Sub CreatePublicteDirectory(user As String, dir As DirectoryInfo)
        Dim dacl As System.Security.AccessControl.DirectorySecurity = New System.Security.AccessControl.DirectorySecurity()
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule("User", System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow))
        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.Read, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Allow))

        dacl.AddAccessRule(New FileSystemAccessRule("Hitelesített felhasználók", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))
        dacl.AddAccessRule(New FileSystemAccessRule(user, FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))
        dacl.AddAccessRule(New FileSystemAccessRule("User", FileSystemRights.ExecuteFile, System.Security.AccessControl.InheritanceFlags.ContainerInherit Or System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, AccessControlType.Deny))

        'System.IO.Directory.CreateDirectory("C:\FruitBat", dacl)

        dir.Create(dacl)
    End Sub
    Public Shared Function Get_All_Users() As List(Of User)
        Dim oquery = New System.Management.ObjectQuery("SELECT * FROM Win32_UserAccount")
        Dim mosearcher = New System.Management.ManagementObjectSearcher(oquery)
        Dim moc = mosearcher.Get()
        Dim Users As New List(Of User)
        Dim Names As New List(Of String)
        '    Dim localUsers = Get_Local_Users()
        For Each mo In moc
            Users.Add(New User(mo))

        Next
        Dim oquery1 = New System.Management.ObjectQuery("SELECT * FROM Win32_Account")
        Dim mosearcher1 = New System.Management.ManagementObjectSearcher(oquery)
        Dim moc1 = mosearcher.Get()
        Return Users
        Dim jj As Int32 = 54
    End Function
    Public Shared Function Get_Local_Users() As List(Of String)
        Dim WinNt As New DirectoryServices.DirectoryEntry("WinNT://localhost")
        Dim UserList As New List(Of String)

        For Each User As DirectoryServices.DirectoryEntry In WinNt.Children
            If User.SchemaClassName = "User" Then
                UserList.Add(User.Name)
            ElseIf User.SchemaClassName = "Group" Then
                Dim kj As Int16 = 54
            Else
                Dim jk As Int16 = 54
            End If
        Next

        Return UserList
    End Function

    Public Shared Sub RemoveDirectorySecurity(ByVal dInfo As DirectoryInfo, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)

        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

        dSecurity.RemoveAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))
        dInfo.SetAccessControl(dSecurity)
    End Sub
End Class

Public Class User
    Private mo As ManagementBaseObject

    Public Sub New(mo As ManagementBaseObject)
        Me.mo = mo
        Me.Name = mo.Properties("Name").Value.ToString()
        Me.Domain = mo.Properties("Domain").Value.ToString()
        Me.DomainwUser = Me.Domain & "\" & Me.Name
        Me.AccountType = mo.Properties("AccountType").Value.ToString()

        Me.Disabled = mo.Properties("Disabled").Value.ToString()
        Dim t = mo.Properties
        Dim t1 = mo.SystemProperties
        Dim kwj As Int16 = 54
    End Sub
    Public Property Name As String
    Public Property Domain As String
    Public Property DomainwUser As String
    Public Property IsSystem As Boolean = False
    Public Property AccountType As Int32
    Public Property Disabled As Boolean = True
End Class