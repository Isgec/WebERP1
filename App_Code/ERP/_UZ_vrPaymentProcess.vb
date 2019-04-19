Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrPaymentProcess
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.VR.vrPaymentProcess
      Dim Results As SIS.VR.vrPaymentProcess = vrPaymentProcessGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_vrPaymentProcessSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrPaymentProcess)
      Dim Results As List(Of SIS.VR.vrPaymentProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_PaymentProcessSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrPaymentProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPaymentProcess(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrPaymentProcessInsert(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Dim _Result As SIS.VR.vrPaymentProcess = vrPaymentProcessInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrPaymentProcessUpdate(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Dim _Result As SIS.VR.vrPaymentProcess = vrPaymentProcessUpdate(Record)
      Return _Result
    End Function
    Private Shared Function GetProjectCompany(ByVal ProjectID As String) As String
      Dim mRet As String = ""
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_ncmp As Company "
      Sql &= " ,t_rsac As Activity "
      Sql &= " From ttppdm600200 "
      Sql &= " Where t_cprj = '" & ProjectID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = rd("Company")
          End If
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function PaymentInBaaNByIRNo(ByVal IRNo As String, ByVal ProjectID As String) As List(Of SIS.VR.VchData)
      Dim Results As List(Of SIS.VR.VchData) = Nothing
      Dim comp As String = "200"
      comp = GetProjectCompany(ProjectID)
      Dim Sql As String = ""
      Sql = Sql & "  select "
      Sql = Sql & "    ir.t_ninv as IRNo,"
      Sql = Sql & "    ir.t_ctyp as PTR,"
      Sql = Sql & "    ir.t_cinv as PTRNo,"
      Sql = Sql & "    pb.t_refr as PaymentReference,"
      Sql = Sql & "    pb.t_pdat as PTRDate,"
      Sql = Sql & "    pb.t_amnt as BankVoucherAmount,"
      Sql = Sql & "    pb.t_amth_1 as PaidAmount,"
      Sql = Sql & "    pb.t_btno as Batch,"
      Sql = Sql & "    pb.t_ptyp as BankVoucherType,"
      Sql = Sql & "    pb.t_pdoc as BankVoucherNo,"
      Sql = Sql & "    pb.t_pdat as BankVoucherDate,"
      Sql = Sql & "    cq.t_cheq as ChequeNo,"
      Sql = Sql & "    cq.t_dout as ChequeDate,"
      Sql = Sql & "    cq.t_amnt as ChequeAmount,"
      Sql = Sql & "    cq.t_chnm as PaymentDescription,"
      Sql = Sql & "    cq.t_drec as ReconciledOn,"
      Sql = Sql & "    (case when cq.t_drec ='' then 0 else 1 end) as Freezed, "
      Sql = Sql & "    bt.t_user as ProcessedBy,"
      Sql = Sql & "    bt.t_date as ProcessedOn, "
      Sql = Sql & "    isnull((select sum(t_amth_1) from ttfgld102200 where t_cono='" & comp & "' and t_ttyp=ir.t_ctyp and t_docn=ir.t_cinv and t_dbcr=2 ),0) as gld102Amth,"
      Sql = Sql & "    isnull((select top 1 t_dcdt from ttfgld102200 where t_cono='" & comp & "' and t_ttyp=ir.t_ctyp and t_docn=ir.t_cinv and t_dbcr=2 ),'') as gld102Date,"
      Sql = Sql & "    isnull((select sum(t_amth_1) from ttfgld106" & comp & " where t_otyp=ir.t_ctyp and t_odoc=ir.t_cinv and t_dbcr=2 ),0) as gld106Amth,"
      Sql = Sql & "    isnull((select top 1 t_dcdt from ttfgld106" & comp & " where t_otyp=ir.t_ctyp and t_odoc=ir.t_cinv and t_dbcr=2 ),'') as gld106Date "
      Sql = Sql & "  from ttfacp100200 as ir "
      Sql = Sql & "    inner join ttfcmg101200 as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv and pb.t_comp='" & comp & "' and t_tadv=1)  "
      Sql = Sql & "    inner join ttfcmg100200 as cq on pb.t_btno = cq.t_pbtn "
      Sql = Sql & "    inner join ttfcmg109200 as bt on pb.t_btno = bt.t_btno "
      Sql = Sql & "  where ir.t_ctyp = 'PTR' and ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.VR.VchData)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.VchData(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
  Public Class VchData
    Private Shared _RecordCount As Integer
    Public Property SerialNo As Int32 = 0
    Public Property PTRNo As String = ""
    Private _PTRDate As String = ""
    Private _PTRAmount As Decimal = 0
    Public Property PaymentReference As String = ""
    Public Property ChequeNo As String = ""
    Public Property ChequeDate As String = ""
    Public Property ChequeAmount As Decimal = 0
    Public Property PaymentDescription As String = ""
    Public Property ProcessedBy As String = ""
    Public Property ProcessedOn As String = ""
    Public Property Freezed As Boolean = False
    Public Property IRNo As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property FK_VR_PaymentProcess_ProcessedBy As SIS.QCM.qcmUsers = Nothing
    Public Property gld102Amth As Decimal = 0
    Public Property gld102Date As String = ""
    Public Property gld106Amth As Decimal = 0
    Public Property gld106Date As String = ""
    Public Property BankVoucherType As String = ""
    Public Property BankVoucherNo As String = ""
    Public Property BankVoucherDate As String = ""
    Public Property BankVoucherAmount As Decimal = 0

    Public ReadOnly Property PTRAmount As Decimal
      Get
        If gld102Amth > 0 Then Return gld102Amth Else Return gld106Amth
      End Get
    End Property
    Public ReadOnly Property PTRDate As String
      Get
        If Year(Convert.ToDateTime(gld102Date)) > 2000 Then Return gld102Date Else Return gld106Date
      End Get
    End Property
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub

  End Class
End Namespace
