'Owen Fujii
'RCET 2265
'Spring 2024
'Address Label
'

Option Explicit On
Option Strict On

Public Class AddressLabelForm

    Private Sub StartUp(sender As Object, e As EventArgs) Handles Me.Load
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function CreateDisplay() As String
        Dim displayText As String
        Dim lettersOfFirst As String
        Dim lettersOfLast As String
        Dim fullName As String
        Dim fullAddress As String
        Dim zipInt As Integer
        Dim formatErrors As String
        Dim foundError As Boolean

        'two methods which convert the inputs from the name textboxs into only their letter components

        lettersOfFirst = String.Concat(FirstNameTextBox.Text.Where(AddressOf Char.IsLetter))
        lettersOfLast = String.Concat(LastNameTextBox.Text.Where(AddressOf Char.IsLetter))

        'Concatenates the first and last names as only letters into one variable
        fullName = lettersOfFirst & lettersOfLast

        If Len(StateTextBox.Text) = 2 Then
            fullAddress = CityTextBox.Text & "," & StateTextBox.Text & " " & ZipTextBox.Text
        Else
            formatErrors = "Please use the State Abbreviation" & vbNewLine
            foundError = True
        End If

        Try
            zipInt = CInt(ZipTextBox.Text)
        Catch ex As Exception
            formatErrors = "Zip can only be numbers"
            foundError = True
        End Try

        If foundError = False Then
            displayText = fullName & vbNewLine & StreetAddressTextBox.Text & vbNewLine & fullAddress
        ElseIf foundError = True Then
            MsgBox(formatErrors)
            displayText = ""
        End If

        Return displayText
    End Function

    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        DisplayLabel.Text = CreateDisplay()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DisplayLabel.Text = ""
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
    End Sub
End Class
