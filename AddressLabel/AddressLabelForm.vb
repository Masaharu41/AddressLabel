'Owen Fujii
'RCET 2265
'Spring 2024
'Address Label
'https://github.com/Masaharu41/AddressLabel.git

Option Explicit On
Option Strict On

Public Class AddressLabelForm

    Private Sub StartUp(sender As Object, e As EventArgs) Handles Me.Load
        'Clears all displayed data on program load
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'Exits the program 
        Me.Close()
    End Sub
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        'Displays the full display label
        DisplayLabel.Text = CreateDisplay()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'Clears all Displayed Data
        DisplayLabel.Text = ""
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
    End Sub

    Function CreateDisplay() As String
        'function variables 
        Dim displayText As String
        Dim lettersOfFirst As String
        Dim lettersOfLast As String
        Dim fullName As String
        Dim fullAddress As String
        Dim lettersOfState As String
        Dim zipInt As Integer
        Dim formatErrors As String
        Dim foundError As Boolean

        'two methods which convert the inputs from the name textboxs into only their letter components

        lettersOfFirst = String.Concat(FirstNameTextBox.Text.Where(AddressOf Char.IsLetter))
        lettersOfLast = String.Concat(LastNameTextBox.Text.Where(AddressOf Char.IsLetter))

        'Concatenates the first and last names as only letters into one variable
        fullName = lettersOfFirst & lettersOfLast

        'Requires that the state is only two letters long and converts to letters only

        lettersOfState = String.Concat(StateTextBox.Text.Where(AddressOf Char.IsLetter))

        If Len(StateTextBox.Text) = 2 Then
            fullAddress = CityTextBox.Text & "," & UCase(StateTextBox.Text) & " " & ZipTextBox.Text
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


End Class
