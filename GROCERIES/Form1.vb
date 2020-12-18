Public Class frmGroceries
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim objReader As IO.StreamReader
        Dim objWriter As New IO.StreamWriter("E:\CSC301\result.txt")
        Dim strLine As String
        Dim strName As String
        Dim dblPrice As Double
        Dim dblTotal As Double
        Dim strArray() As String
        If IO.File.Exists("E:\CSC301\groceries.txt") = True Then
            objReader = IO.File.OpenText("E:\CSC301\groceries.txt")
        Else
            MsgBox("File is not available")
            Close()
        End If

        Do While objReader.Peek <> -1
            strLine = objReader.ReadLine()
            strArray = strLine.Split(",")
            strName = strArray(0)
            dblPrice = Convert.ToDouble(strArray(1))
            dblTotal = dblTotal + dblPrice
            lstDisplay.Items.Add(strName & " [" & dblPrice.ToString("C") & "]")
            objWriter.WriteLine(strName & " [" & dblPrice.ToString("C") & "]")
        Loop

        lstDisplay.Items.Add("Total price of groceries : " & dblTotal.ToString("C"))
        objWriter.WriteLine("Total price of groceries : " & dblTotal.ToString("C"))

        objReader.Close()
        objWriter.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class
