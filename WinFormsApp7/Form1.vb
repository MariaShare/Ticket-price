Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim ri As Integer
    Dim rj As Integer
    Dim kilom = {{0, 7093, 690, 3834, 2085, 1727, 2728},
                 {7093, 0, 6645, 4247, 5055, 6516, 4507},
                 {690, 6645, 0, 3794, 1828, 2110, 2502},
                 {3834, 4247, 3794, 0, 2057, 2537, 1467},
                 {2085, 5055, 1828, 2057, 0, 1784, 674},
                 {1727, 6516, 2110, 2537, 1784, 0, 2083},
                 {2728, 4507, 2502, 1467, 674, 2083, 0}}
    Dim speedAirplane = 700
    Dim res = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Место отправления"
        Label2.Text = "Место прибытия"
        Label3.Text = "Условия обслуживания"
        Label4.Text = "Расположение места"
        Label5.Text = ""
        Button1.Text = "Выбрать билет"
        Button2.Text = "Рассчитать"
        CheckBox1.Text = "Салон для курения"
        CheckBox2.Text = "X"
        ComboBox1.Items.AddRange({"Анапа", "Владивосток", "Грозный", "Диксон",
                                  "Екатеринбург", "Санкт-Петербург", "Ханты-Мансийск"})
        ComboBox2.Items.AddRange({"Анапа", "Владивосток", "Грозный", "Диксон",
                                  "Екатеринбург", "Санкт-Петербург", "Ханты-Мансийск"})
        ComboBox3.Items.AddRange({"Эконом", "Премиум", "Бизнес"})
        ComboBox4.Items.AddRange({"Окно", "Середина", "У выхода"})
    End Sub
    Private Sub Case1(sender As Object, e As EventArgs) Handles Button2.Click
        res = 0
        If ComboBox1.SelectedIndex < 0 Then
            MsgBox("Выберите город отправления")
        Else
            Dim F1 = ComboBox1.SelectedIndex
            Select Case F1
                Case 0
                    ri = 0
                Case 1
                    ri = 1
                Case 2
                    ri = 2
                Case 3
                    ri = 3
                Case 4
                    ri = 4
                Case 5
                    ri = 5
                Case 6
                    ri = 6
            End Select
            Case2(F1)
        End If
    End Sub
    Private Sub Case2(F1 As Integer)
        Dim F2 = ComboBox2.SelectedIndex
        If F1 = F2 Then
            MsgBox("Выберите разные города")
        Else
            If ComboBox2.SelectedIndex < 0 Then
                MsgBox("Выберите город прибытия!")
            Else
                Select Case F2
                    Case 0
                        rj = 0
                    Case 1
                        rj = 1
                    Case 2
                        rj = 2
                    Case 3
                        rj = 3
                    Case 4
                        rj = 4
                    Case 5
                        rj = 5
                    Case 6
                        rj = 6
                End Select
                res = kilom(ri, rj) / speedAirplane * 1420
                Case3()
            End If
        End If
    End Sub
    Private Sub Case3()
        Dim F3 = ComboBox3.SelectedIndex
        If ComboBox3.SelectedIndex < 0 Then
            MsgBox("Выберите условия обслуживания!")
        Else
            Select Case F3
                Case 0
                    res = res * 1.1
                Case 1
                    res = res * 1.25
                Case 2
                    res = res * 1.5
            End Select
            Case5()
        End If
    End Sub
    Private Sub Case5()
        If CheckBox1.Checked Then
            res += 3000
        End If
        Case4()
    End Sub
    Private Sub Case4()
        Dim F4 = ComboBox4.SelectedIndex
        If ComboBox4.SelectedIndex < 0 Then
            MsgBox("Выберите условия обслуживания!")
        Else
            Select Case F4
                Case 0
                    res = res * 1.5
                Case 1
                    res = res * 1.25
                Case 2
                    res = res * 1.1
            End Select
            Out_Label()
        End If
    End Sub
    Private Sub Out_Label()
        Label5.Text = "Стоимость билета: " + Str(Math.Round(res)) + "р."
    End Sub
    Private Sub ShowPanel(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = True
    End Sub
    Private Sub HidePanel(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Panel1.Visible = False
        CheckBox2.CheckState = False
        CheckBox1.Checked = False
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
    End Sub
End Class
