Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  <DataObject()> _
  Partial Public Class lgEPAttachment
    Private Shared _RecordCount As Integer
    Private _DocPK As Int64 = 0
    Private _FilePK As Int64 = 0
    Private _DocumentID As String = ""
    Private _Revision As String = ""
    Private _Iteration As String = ""
    Private _Status As String = ""
    Private _CreatedOn As String = ""
    Private _UpdatedOn As String = ""
    Private _Title As String = ""
    Private _DocType As String = ""
    Private _Attachment As String = ""
    Private _ProjectID As String = ""
    Private _ElementID As String = ""
    Private _ProjectDescription As String = ""
    Private _ElementDescription As String = ""
    Private _DiskFileName As String = ""
    Private _category As String = ""
    Private _fileSize As String = ""
    Private _FileNumber As String = ""
    Private _path As String = ""
    Private _DownloadedFileLocation As String = ""
    Private _DownloadedFileName As String = ""
    Private _LG_EPDocument1_DocumentID As String = ""
    Private _LG_Projects2_ProjectDescription As String = ""
    Private _FK_LG_EPAttachment_DocPK As SIS.LG.lgEPDocument = Nothing
    Private _FK_LG_EPAttachment_ProjectID As SIS.LG.lgProjects = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property DocPK() As Int64
      Get
        Return _DocPK
      End Get
      Set(ByVal value As Int64)
        _DocPK = value
      End Set
    End Property
    Public Property FilePK() As Int64
      Get
        Return _FilePK
      End Get
      Set(ByVal value As Int64)
        _FilePK = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
        _DocumentID = value
      End Set
    End Property
    Public Property Revision() As String
      Get
        Return _Revision
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Revision = ""
				 Else
					 _Revision = value
			   End If
      End Set
    End Property
    Public Property Iteration() As String
      Get
        Return _Iteration
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Iteration = ""
				 Else
					 _Iteration = value
			   End If
      End Set
    End Property
    Public Property Status() As String
      Get
        Return _Status
      End Get
      Set(ByVal value As String)
        _Status = value
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedOn = ""
				 Else
					 _CreatedOn = value
			   End If
      End Set
    End Property
    Public Property UpdatedOn() As String
      Get
        If Not _UpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_UpdatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _UpdatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UpdatedOn = ""
				 Else
					 _UpdatedOn = value
			   End If
      End Set
    End Property
    Public Property Title() As String
      Get
        Return _Title
      End Get
      Set(ByVal value As String)
        _Title = value
      End Set
    End Property
    Public Property DocType() As String
      Get
        Return _DocType
      End Get
      Set(ByVal value As String)
        _DocType = value
      End Set
    End Property
    Public Property Attachment() As String
      Get
        Return _Attachment
      End Get
      Set(ByVal value As String)
        _Attachment = value
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ElementID = ""
				 Else
					 _ElementID = value
			   End If
      End Set
    End Property
    Public Property ProjectDescription() As String
      Get
        Return _ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectDescription = ""
				 Else
					 _ProjectDescription = value
			   End If
      End Set
    End Property
    Public Property ElementDescription() As String
      Get
        Return _ElementDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ElementDescription = ""
				 Else
					 _ElementDescription = value
			   End If
      End Set
    End Property
    Public Property DiskFileName() As String
      Get
        Return _DiskFileName
      End Get
      Set(ByVal value As String)
        _DiskFileName = value
      End Set
    End Property
    Public Property category() As String
      Get
        Return _category
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _category = ""
				 Else
					 _category = value
			   End If
      End Set
    End Property
    Public Property fileSize() As String
      Get
        Return _fileSize
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _fileSize = ""
				 Else
					 _fileSize = value
			   End If
      End Set
    End Property
    Public Property FileNumber() As String
      Get
        Return _FileNumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FileNumber = ""
				 Else
					 _FileNumber = value
			   End If
      End Set
    End Property
    Public Property path() As String
      Get
        Return _path
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _path = ""
				 Else
					 _path = value
			   End If
      End Set
    End Property
    Public Property DownloadedFileLocation() As String
      Get
        Return _DownloadedFileLocation
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DownloadedFileLocation = ""
				 Else
					 _DownloadedFileLocation = value
			   End If
      End Set
    End Property
    Public Property DownloadedFileName() As String
      Get
        Return _DownloadedFileName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DownloadedFileName = ""
				 Else
					 _DownloadedFileName = value
			   End If
      End Set
    End Property
    Public Property LG_EPDocument1_DocumentID() As String
      Get
        Return _LG_EPDocument1_DocumentID
      End Get
      Set(ByVal value As String)
        _LG_EPDocument1_DocumentID = value
      End Set
    End Property
    Public Property LG_Projects2_ProjectDescription() As String
      Get
        Return _LG_Projects2_ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LG_Projects2_ProjectDescription = ""
				 Else
					 _LG_Projects2_ProjectDescription = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DocPK & "|" & _FilePK
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKlgEPAttachment
			Private _DocPK As Int64 = 0
			Private _FilePK As Int64 = 0
			Public Property DocPK() As Int64
				Get
					Return _DocPK
				End Get
				Set(ByVal value As Int64)
					_DocPK = value
				End Set
			End Property
			Public Property FilePK() As Int64
				Get
					Return _FilePK
				End Get
				Set(ByVal value As Int64)
					_FilePK = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_LG_EPAttachment_DocPK() As SIS.LG.lgEPDocument
      Get
        If _FK_LG_EPAttachment_DocPK Is Nothing Then
          _FK_LG_EPAttachment_DocPK = SIS.LG.lgEPDocument.lgEPDocumentGetByID(_DocPK)
        End If
        Return _FK_LG_EPAttachment_DocPK
      End Get
    End Property
    Public ReadOnly Property FK_LG_EPAttachment_ProjectID() As SIS.LG.lgProjects
      Get
        If _FK_LG_EPAttachment_ProjectID Is Nothing Then
          _FK_LG_EPAttachment_ProjectID = SIS.LG.lgProjects.lgProjectsGetByID(_ProjectID)
        End If
        Return _FK_LG_EPAttachment_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttachmentGetNewRecord() As SIS.LG.lgEPAttachment
      Return New SIS.LG.lgEPAttachment()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttachmentGetByID(ByVal DocPK As Int64, ByVal FilePK As Int64) As SIS.LG.lgEPAttachment
      Dim Results As SIS.LG.lgEPAttachment = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttachmentSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FilePK",SqlDbType.BigInt,FilePK.ToString.Length, FilePK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgEPAttachment(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByDocPK(ByVal DocPK As Int64, ByVal OrderBy as String) As List(Of SIS.LG.lgEPAttachment)
      Dim Results As List(Of SIS.LG.lgEPAttachment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttachmentSelectByDocPK"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttachment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttachment(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.LG.lgEPAttachment)
      Dim Results As List(Of SIS.LG.lgEPAttachment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttachmentSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttachment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttachment(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttachmentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As List(Of SIS.LG.lgEPAttachment)
      Dim Results As List(Of SIS.LG.lgEPAttachment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splgEPAttachmentSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splgEPAttachmentSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocPK",SqlDbType.BigInt,19, IIf(DocPK = Nothing, 0,DocPK))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttachment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttachment(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function lgEPAttachmentSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttachmentGetByID(ByVal DocPK As Int64, ByVal FilePK As Int64, ByVal Filter_DocPK As Int64) As SIS.LG.lgEPAttachment
      Return lgEPAttachmentGetByID(DocPK, FilePK)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function lgEPAttachmentUpdate(ByVal Record As SIS.LG.lgEPAttachment) As SIS.LG.lgEPAttachment
      Dim _Rec As SIS.LG.lgEPAttachment = SIS.LG.lgEPAttachment.lgEPAttachmentGetByID(Record.DocPK, Record.FilePK)
      With _Rec
        .DocumentID = Record.DocumentID
        .Revision = Record.Revision
        .Iteration = Record.Iteration
        .Status = Record.Status
        .CreatedOn = Record.CreatedOn
        .UpdatedOn = Record.UpdatedOn
        .Title = Record.Title
        .DocType = Record.DocType
        .Attachment = Record.Attachment
        .ProjectID = Record.ProjectID
        .ElementID = Record.ElementID
        .ProjectDescription = Record.ProjectDescription
        .ElementDescription = Record.ElementDescription
        .DiskFileName = Record.DiskFileName
        .category = Record.category
        .fileSize = Record.fileSize
        .FileNumber = Record.FileNumber
        .path = Record.path
        .DownloadedFileLocation = Record.DownloadedFileLocation
        .DownloadedFileName = Record.DownloadedFileName
      End With
      Return SIS.LG.lgEPAttachment.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.LG.lgEPAttachment) As SIS.LG.lgEPAttachment
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttachmentUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocPK",SqlDbType.BigInt,20, Record.DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FilePK",SqlDbType.BigInt,20, Record.FilePK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,20, Record.DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FilePK",SqlDbType.BigInt,20, Record.FilePK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,101, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.NVarChar,11, Iif(Record.Revision= "" ,Convert.DBNull, Record.Revision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Iteration",SqlDbType.NVarChar,11, Iif(Record.Iteration= "" ,Convert.DBNull, Record.Iteration))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Status",SqlDbType.NVarChar,31, Record.Status)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedOn",SqlDbType.DateTime,21, Iif(Record.UpdatedOn= "" ,Convert.DBNull, Record.UpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Title",SqlDbType.NVarChar,201, Record.Title)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocType",SqlDbType.VarChar,13, Record.DocType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Attachment",SqlDbType.NVarChar,21, Record.Attachment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,21, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectDescription",SqlDbType.NVarChar,101, Iif(Record.ProjectDescription= "" ,Convert.DBNull, Record.ProjectDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementDescription",SqlDbType.NVarChar,201, Iif(Record.ElementDescription= "" ,Convert.DBNull, Record.ElementDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFileName",SqlDbType.NVarChar,201, Record.DiskFileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@category",SqlDbType.NVarChar,21, Iif(Record.category= "" ,Convert.DBNull, Record.category))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@fileSize",SqlDbType.BigInt,20, Iif(Record.fileSize= "" ,Convert.DBNull, Record.fileSize))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileNumber",SqlDbType.BigInt,20, Iif(Record.FileNumber= "" ,Convert.DBNull, Record.FileNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@path",SqlDbType.NVarChar,201, Iif(Record.path= "" ,Convert.DBNull, Record.path))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadedFileLocation",SqlDbType.NVarChar,1001, Iif(Record.DownloadedFileLocation= "" ,Convert.DBNull, Record.DownloadedFileLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadedFileName",SqlDbType.NVarChar,201, Iif(Record.DownloadedFileName= "" ,Convert.DBNull, Record.DownloadedFileName))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _DocPK = Ctype(Reader("DocPK"),Int64)
      _FilePK = Ctype(Reader("FilePK"),Int64)
      _DocumentID = Ctype(Reader("DocumentID"),String)
      If Convert.IsDBNull(Reader("Revision")) Then
        _Revision = String.Empty
      Else
        _Revision = Ctype(Reader("Revision"), String)
      End If
      If Convert.IsDBNull(Reader("Iteration")) Then
        _Iteration = String.Empty
      Else
        _Iteration = Ctype(Reader("Iteration"), String)
      End If
      _Status = Ctype(Reader("Status"),String)
      If Convert.IsDBNull(Reader("CreatedOn")) Then
        _CreatedOn = String.Empty
      Else
        _CreatedOn = Ctype(Reader("CreatedOn"), String)
      End If
      If Convert.IsDBNull(Reader("UpdatedOn")) Then
        _UpdatedOn = String.Empty
      Else
        _UpdatedOn = Ctype(Reader("UpdatedOn"), String)
      End If
      _Title = Ctype(Reader("Title"),String)
      _DocType = Ctype(Reader("DocType"),String)
      _Attachment = Ctype(Reader("Attachment"),String)
      _ProjectID = Ctype(Reader("ProjectID"),String)
      If Convert.IsDBNull(Reader("ElementID")) Then
        _ElementID = String.Empty
      Else
        _ElementID = Ctype(Reader("ElementID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectDescription")) Then
        _ProjectDescription = String.Empty
      Else
        _ProjectDescription = Ctype(Reader("ProjectDescription"), String)
      End If
      If Convert.IsDBNull(Reader("ElementDescription")) Then
        _ElementDescription = String.Empty
      Else
        _ElementDescription = Ctype(Reader("ElementDescription"), String)
      End If
      _DiskFileName = Ctype(Reader("DiskFileName"),String)
      If Convert.IsDBNull(Reader("category")) Then
        _category = String.Empty
      Else
        _category = Ctype(Reader("category"), String)
      End If
      If Convert.IsDBNull(Reader("fileSize")) Then
        _fileSize = String.Empty
      Else
        _fileSize = Ctype(Reader("fileSize"), String)
      End If
      If Convert.IsDBNull(Reader("FileNumber")) Then
        _FileNumber = String.Empty
      Else
        _FileNumber = Ctype(Reader("FileNumber"), String)
      End If
      If Convert.IsDBNull(Reader("path")) Then
        _path = String.Empty
      Else
        _path = Ctype(Reader("path"), String)
      End If
      If Convert.IsDBNull(Reader("DownloadedFileLocation")) Then
        _DownloadedFileLocation = String.Empty
      Else
        _DownloadedFileLocation = Ctype(Reader("DownloadedFileLocation"), String)
      End If
      If Convert.IsDBNull(Reader("DownloadedFileName")) Then
        _DownloadedFileName = String.Empty
      Else
        _DownloadedFileName = Ctype(Reader("DownloadedFileName"), String)
      End If
      _LG_EPDocument1_DocumentID = Ctype(Reader("LG_EPDocument1_DocumentID"),String)
      If Convert.IsDBNull(Reader("LG_Projects2_ProjectDescription")) Then
        _LG_Projects2_ProjectDescription = String.Empty
      Else
        _LG_Projects2_ProjectDescription = Ctype(Reader("LG_Projects2_ProjectDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
