Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  Partial Public Class erpCreateTPTBill
    Public ReadOnly Property GetAttachLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=J_TRANSPORTERBILL"
        Dim Index As String = SerialNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        'User = 1
        Dim canEdit As String = "n"
        If InitiateWFVisible Then
          canEdit = "y"
        End If
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        mRet = "javascript:window.open('" & mRet & "', 'win_" & SerialNo & "', 'left=20,top=20,width=600,height=400,toolbar=0,resizable=1,scrollbars=1'); return false;"

        Return mRet
      End Get
    End Property

    Private _IRNumber As String = ""
    Private _ReasonID As String = ""
    Private _NewBillStatus As String = ""

    Private _BackToTownCharges As String = 0
    Private _TarpaulinCharges As String = 0
    Private _WoodenSleeperCharges As String = 0
    Private _DetentionatDaysULP As String = 0
    Private _ULPisICDCFSPort As Boolean = False
    Private _DetentionatDaysLP As String = 0
    Private _LPisISGECWorks As Boolean = False
    Public Property ErrMessage As String = ""
    Public Property RecordType As String = ""
    Public ReadOnly Property dRecordType As String
      Get
        If RecordType <> "" Then Return RecordType.Substring(0, 1) Else Return ""
      End Get
    End Property
    Public Property BackToTownCharges() As String
      Get
        Return _BackToTownCharges
      End Get
      Set(ByVal value As String)
        If Not Convert.IsDBNull(value) Then
          _BackToTownCharges = value
        Else
          _BackToTownCharges = 0
        End If
      End Set
    End Property
    Public Property TarpaulinCharges() As String
      Get
        Return _TarpaulinCharges
      End Get
      Set(ByVal value As String)
        If Not Convert.IsDBNull(value) Then
          _TarpaulinCharges = value
        Else
          _TarpaulinCharges = 0
        End If

      End Set
    End Property
    Public Property WoodenSleeperCharges() As String
      Get
        Return _WoodenSleeperCharges
      End Get
      Set(ByVal value As String)
        If Not Convert.IsDBNull(value) Then
          _WoodenSleeperCharges = value
        Else
          _WoodenSleeperCharges = 0
        End If

      End Set
    End Property
    Public Property DetentionatDaysULP() As String
      Get
        Return _DetentionatDaysULP
      End Get
      Set(ByVal value As String)
        If Not Convert.IsDBNull(value) Then
          _DetentionatDaysULP = value
        Else
          _DetentionatDaysULP = 0
        End If

      End Set
    End Property
    Public Property ULPisICDCFSPort() As Boolean
      Get
        Return _ULPisICDCFSPort
      End Get
      Set(ByVal value As Boolean)
        _ULPisICDCFSPort = value
      End Set
    End Property
    Public Property DetentionatDaysLP() As String
      Get
        Return _DetentionatDaysLP
      End Get
      Set(ByVal value As String)
        If Not Convert.IsDBNull(value) Then
          _DetentionatDaysLP = value
        Else
          _DetentionatDaysLP = 0
        End If
      End Set
    End Property
    Public Property LPisISGECWorks() As Boolean
      Get
        Return _LPisISGECWorks
      End Get
      Set(ByVal value As Boolean)
        _LPisISGECWorks = value
      End Set
    End Property



    Public Property NewBillStatus() As String
      Get
        Return _NewBillStatus
      End Get
      Set(ByVal value As String)
        _NewBillStatus = value
      End Set
    End Property
    Public Property ReasonID() As String
      Get
        Return _ReasonID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReasonID = ""
        Else
          _ReasonID = value
        End If
      End Set
    End Property
    Public Property IRNumber() As String
      Get
        Return _IRNumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IRNumber = ""
        Else
          _IRNumber = value
        End If
      End Set
    End Property
    Public Shared Function erpCreateTPTBillGetByIRNumber(ByVal IRNumber As String) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperp_LG_CreateTPTBillSelectByIRNumber"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNumber", SqlDbType.NVarChar, 11, IRNumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ERP.erpCreateTPTBill(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Select Case _BillStatus
        Case TptBillStatus.Cancelled
        Case TptBillStatus.Free
          mRet = Drawing.Color.Black
        Case TptBillStatus.UnderReceiveByAccounts
          mRet = Drawing.Color.DarkOrange
        Case TptBillStatus.UnderPaymentProcessing
          mRet = Drawing.Color.Green
        Case TptBillStatus.UnderReceiveByLogistics
          mRet = Drawing.Color.Red
        Case TptBillStatus.UnderReSubmitbyLogistics
          mRet = Drawing.Color.DarkOrchid
        Case TptBillStatus.PaymentProcessed
          mRet = Drawing.Color.DarkMagenta
        Case TptBillStatus.Closed
          mRet = Drawing.Color.DarkGoldenrod
      End Select
      If Unlocked Then
        mRet = Drawing.Color.Red
      End If
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _BillStatus
            Case TptBillStatus.Free
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _BillStatus
            Case TptBillStatus.UnderReceiveByLogistics
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _BillStatus
            Case TptBillStatus.UnderReSubmitbyLogistics
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _BillStatus
            Case TptBillStatus.PaymentProcessed
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
      With Results
        .FWDToAccountsBy = HttpContext.Current.Session("LoginID")
        .FWDToAccountsOn = Now
        .BillStatus = TptBillStatus.UnderReceiveByAccounts
      End With
      SIS.ERP.erpCreateTPTBill.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
      With Results
        .DiscRecdInLgstBy = HttpContext.Current.Session("LoginID")
        .DiscRecdInLgstOn = Now
        .BillStatus = TptBillStatus.UnderReSubmitbyLogistics
      End With
      SIS.ERP.erpCreateTPTBill.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
      With Results
        .ReFwdToAcBy = HttpContext.Current.Session("LoginID")
        .ReFwdToACOn = Now
        .BillStatus = TptBillStatus.UnderReceiveByAccounts
      End With
      SIS.ERP.erpCreateTPTBill.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
      If Results.ChequeNo = String.Empty Then
        Throw New Exception("Cheque No. NOT Entered.")
      End If
      Results.BillStatus = TptBillStatus.Closed
      SIS.ERP.erpCreateTPTBill.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_erpCreateTPTBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32, ByVal Pending As Boolean) As List(Of SIS.ERP.erpCreateTPTBill)
      Dim Results As List(Of SIS.ERP.erpCreateTPTBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sperp_LG_CreateTPTBillSelectListSearch"
            Cmd.CommandText = "sperpCreateTPTBillSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sperp_LG_CreateTPTBillSelectListFilteres"
            Cmd.CommandText = "sperpCreateTPTBillSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TPTCode", SqlDbType.NVarChar, 9, IIf(TPTCode Is Nothing, String.Empty, TPTCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatus", SqlDbType.Int, 10, IIf(BillStatus = Nothing, 0, BillStatus))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Pending", SqlDbType.Bit, 3, Pending)
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpCreateTPTBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpCreateTPTBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpCreateTPTBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32, ByVal Pending As Boolean) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UZ_erpCreateTPTBillInsert(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Dim NextClubNo As String = ""
      Select Case Record.BillType
        Case ""
        Case "Freight Bill"
        Case "Freight Bill With Detention"
        Case "Freight And Detention Separate Bills"
          NextClubNo = GetNextClubNo()
      End Select
      Record.ClubbingNo = NextClubNo
      Record.BillStatus = 2
      Record.CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      Record.CreatedOn = Now
      Record.RecordType = "Freight"
      Dim _Result As SIS.ERP.erpCreateTPTBill = InsertData(Record)
      Select Case Record.BillType
        Case ""
        Case "Freight Bill"
        Case "Freight Bill With Detention"
        Case "Freight And Detention Separate Bills"
          Dim dRecord As New SIS.ERP.erpCreateTPTBill
          With dRecord
            .ClubbingNo = NextClubNo
            .BillStatus = 2
            .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
            .CreatedOn = Now
            .BillType = Record.BillType
            .RecordType = "Detention"
            .[TPTBillNo] = Record.dTPTBillNo
            .[IRNumber] = Record.dIRNumber
            .[TPTBillDate] = Record.dTPTBillDate
            .[TPTBillReceivedOn] = Record.dTPTBillReceivedOn
            .[GRNos] = Record.GRNos
            .[TPTCode] = Record.TPTCode
            .[PONumber] = Record.PONumber
            .[ProjectID] = Record.ProjectID
            .[TPTBillAmount] = Record.dTPTBillAmount
            .[DetentionatLP] = Record.dDetentionatLP
            .[DetentionatULP] = Record.dDetentionatULP
            .DetentionatDaysLP = Record.dDetentionatDaysLP
            .LPisISGECWorks = Record.dLPisISGECWorks
            .DetentionatDaysULP = Record.dDetentionatDaysULP
            .ULPisICDCFSPort = Record.dULPisICDCFSPort
            .AssessableValue = Record.dAssessableValue
            .IGSTRate = Record.dIGSTRate
            .IGSTAmount = Record.dIGSTAmount
            .SGSTRate = Record.dSGSTRate
            .SGSTAmount = Record.dSGSTAmount
            .CGSTRate = Record.dCGSTRate
            .CGSTAmount = Record.dCGSTAmount
            .CessRate = Record.dCessRate
            .CessAmount = Record.dCessAmount
            .TotalGST = Record.dTotalGST
            .TotalAmount = Record.dTotalAmount
          End With
          InsertData(dRecord)
      End Select
      Return _Result
    End Function
    Private Shared Function GetNextClubNo() As String
      Dim mRet As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select isnull(max(ClubbingNo),0)+1 as cnt from ERP_TransporterBill"
          Con.Open()
          Dim tmp As String = Cmd.ExecuteScalar
          If tmp IsNot Nothing Then
            mRet = tmp
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UZ_erpCreateTPTBillUpdateUnlocked(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Dim ClubNo As String = ""
      ClubNo = GetNextClubNo()
      Dim frt As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetByID(Record.SerialNo)
      With frt
        .ClubbingNo = ClubNo
        .Unlocked = False
        .RecordType = "Freight"
        .BillType = "Freight And Detention Separate Bills"
      End With
      Dim dRecord As New SIS.ERP.erpCreateTPTBill
      With dRecord
        .ClubbingNo = ClubNo
        .BillStatus = 2
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .BillType = frt.BillType
        .RecordType = "Detention"
        .[TPTBillNo] = Record.dTPTBillNo
        .[IRNumber] = Record.dIRNumber
        .[TPTBillDate] = Record.dTPTBillDate
        .[TPTBillReceivedOn] = Record.dTPTBillReceivedOn
        .[GRNos] = Record.GRNos
        .[TPTCode] = Record.TPTCode
        .[PONumber] = Record.PONumber
        .[ProjectID] = Record.ProjectID
        .[TPTBillAmount] = Record.dTPTBillAmount
        .[DetentionatLP] = Record.dDetentionatLP
        .[DetentionatULP] = Record.dDetentionatULP
        .DetentionatDaysLP = Record.dDetentionatDaysLP
        .LPisISGECWorks = Record.dLPisISGECWorks
        .DetentionatDaysULP = Record.dDetentionatDaysULP
        .ULPisICDCFSPort = Record.dULPisICDCFSPort
        .AssessableValue = Record.dAssessableValue
        .IGSTRate = Record.dIGSTRate
        .IGSTAmount = Record.dIGSTAmount
        .SGSTRate = Record.dSGSTRate
        .SGSTAmount = Record.dSGSTAmount
        .CGSTRate = Record.dCGSTRate
        .CGSTAmount = Record.dCGSTAmount
        .CessRate = Record.dCessRate
        .CessAmount = Record.dCessAmount
        .TotalGST = Record.dTotalGST
        .TotalAmount = Record.dTotalAmount
      End With
      dRecord = InsertData(dRecord)
      frt = UpdateData(frt)
      Return dRecord
    End Function

    Public Shared Function UZ_erpCreateTPTBillUpdate(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Dim _Result As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_erpCreateTPTBillDelete(ByVal Record As SIS.ERP.erpCreateTPTBill) As Integer
      Dim _Result As Integer = erpCreateTPTBillDelete(Record)
      Return _Result
    End Function
    Public Shared Function getIRData(ByVal IRNo As String) As SIS.ERP.erpCreateTPTBill
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim oTptBill As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetByIRNumber(IRNo)
      If oTptBill IsNot Nothing Then
        Throw New Exception("IR Number already used.")
      End If
      Dim Results As SIS.ERP.erpCreateTPTBill = Nothing
      Dim Sql As String = ""
      Sql = Sql & "select "
      Sql = Sql & "ir.t_ninv as IRNo, "
      Sql = Sql & "ir.t_refr as IRDescription, "
      Sql = Sql & "ir.t_cdf_pono as PONumber, "
      Sql = Sql & "ir.t_cdf_irdt as TPTBillReceivedOn, "
      Sql = Sql & "ir.t_cdf_cprj as ProjectID, "
      Sql = Sql & "ir.t_amti as POAmount, "
      Sql = Sql & "ir.t_ifbp as TPTCode,"
      Sql = Sql & "ir.t_isup as TPTBillNo,"
      Sql = Sql & "ir.t_invd as TPTBillDate,"
      Sql = Sql & "ir.t_amti as TPTBillAmount, "
      Sql = Sql & "gst.t_assv as AssessableValue, "
      Sql = Sql & "gst.t_irat as IGSTRate, "
      Sql = Sql & "gst.t_iamt as IGSTAmount, "
      Sql = Sql & "gst.t_srat as SGSTRate, "
      Sql = Sql & "gst.t_samt as SGSTAmount, "
      Sql = Sql & "gst.t_crat as CGSTRate, "
      Sql = Sql & "gst.t_camt as CGSTAmount, "
      Sql = Sql & "gst.t_cess as CessRate, "
      Sql = Sql & "gst.t_cmnt as CessAmount, "
      Sql = Sql & "gst.t_tgmt as TotalGST, "
      Sql = Sql & "gst.t_tval as TotalAmount, "
      Sql = Sql & "gr.t_grno as GRNOs, "
      Sql = Sql & "gr.t_grdt as GRDTs "
      Sql = Sql & "from ttfacp100" & Comp & " as ir "
      Sql = Sql & "left outer join ttfisg407" & Comp & " as gst on ir.t_ninv = gst.t_ninv and gst.t_pono=1 "
      Sql = Sql & "left outer join ttfisg002" & Comp & " as gr on ir.t_ninv = gr.t_irno "
      Sql = Sql & "where ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ERP.erpCreateTPTBill(Reader)
            Results.GRNos = Results.GRNos & " Dt " & Reader("GRDTs")
            While (Reader.Read())
              Results.GRNos = Results.GRNos & ", " & Reader("GRNos") & " Dt " & Reader("GRDTs")
            End While
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Public Shared Function getStrIRData(ByVal oTptBill As SIS.ERP.erpCreateTPTBill) As String
    '  Dim mRet As String = ""
    '  If oTptBill Is Nothing Then Return mRet
    '  With oTptBill
    '    mRet &= "|" & .TPTBillNo
    '    mRet &= "|" & .TPTBillDate
    '    mRet &= "|" & .GRNos
    '    mRet &= "|" & .TPTCode
    '    mRet &= "|" & .PONumber
    '    mRet &= "|" & .ProjectID
    '    mRet &= "|" & .TPTBillAmount
    '    mRet &= "|" & .TPTBillReceivedOn
    '    mRet &= "|" & .AssessableValue
    '    mRet &= "|" & .IGSTRate
    '    mRet &= "|" & .IGSTAmount
    '    mRet &= "|" & .CGSTRate
    '    mRet &= "|" & .CGSTAmount
    '    mRet &= "|" & .SGSTRate
    '    mRet &= "|" & .SGSTAmount
    '    mRet &= "|" & .CessRate
    '    mRet &= "|" & .CessAmount
    '    mRet &= "|" & .TotalGST
    '    mRet &= "|" & .TotalAmount
    '  End With
    '  Return mRet
    'End Function
    Public Shared Function GetByReceiptDate(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal StatusID As String) As List(Of SIS.ERP.erpCreateTPTBill)
      Dim Results As List(Of SIS.ERP.erpCreateTPTBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperp_LG_CreateTPTBillGetByReceiptDate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate", SqlDbType.DateTime, 20, FromDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate", SqlDbType.DateTime, 20, ToDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.NVarChar, 9, StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpCreateTPTBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpCreateTPTBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function getPaymentData(ByVal value As String) As String
      Dim aVal() As String = value.Split(",".ToCharArray)
      Dim mRet As String = "0|" & aVal(0)
      Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
      Dim ProjectID As String = aVal(2)
      Dim Results As List(Of SIS.VR.VchData) = SIS.VR.vrPaymentProcess.PaymentInBaaNByIRNo(IRNo, ProjectID)
      If Results.Count > 0 Then
        With Results(0)
          mRet &= "|" & .PTRNo
          mRet &= "|" & .PTRAmount
          mRet &= "|" & .PTRDate
          mRet &= "|" & .BankVoucherNo
          mRet &= "|" & .BankVoucherAmount
          mRet &= "|" & .BankVoucherDate
        End With
      End If
      Return mRet
    End Function
  End Class
End Namespace
