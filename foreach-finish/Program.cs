using System;

/*
*
* CURIOSIDADE: No código logo abaixo foi corrigido algumas coisas
* Dentre elas, a variavel "sumAssignmentScores", que no site o retorno é int
* Mas o correto é decimal, pois o mesmo não retorna um valor inteiro.
*/

Console.Clear();

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };
int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };

int[] studentScores = new int[10];
int exames = 5;
string currentStudentLetterGrade = "";

Console.WriteLine("Estudante\t\tPontuação\t\tTotal\t\tLetra\t\tCredito Extra\n");

foreach (string name in studentNames)
{
    string Student = name;
    decimal sumAssignmentScores = 0;
    decimal currentStudentGrade = 0;
    decimal gradedAssignments = 0;
    decimal notas = 0;

    if (Student == "Sophia") studentScores = sophiaScores;
    else if (Student == "Andrew") studentScores = andrewScores;
    else if (Student == "Emma") studentScores = emmaScores;
    else if (Student == "Logan") studentScores = loganScores;
    else if (Student == "Becky") studentScores = beckyScores;
    else if (Student == "Chris") studentScores = chrisScores;
    else if (Student == "Eric") studentScores = ericScores;
    else if (Student == "Gregor") studentScores = gregorScores;
    else continue;

    foreach (int score in studentScores)
    {
        gradedAssignments += 1;
        if (gradedAssignments <= exames) sumAssignmentScores += (decimal)score;
        else sumAssignmentScores += (decimal)(score / 10m);
        notas += (decimal)score;
    }
    currentStudentGrade = (decimal)(sumAssignmentScores / exames);

    if (currentStudentGrade >= 97) currentStudentLetterGrade = "A+";
    else if (currentStudentGrade >= 93) currentStudentLetterGrade = "A";
    else if (currentStudentGrade >= 90) currentStudentLetterGrade = "A-";
    else if (currentStudentGrade >= 87) currentStudentLetterGrade = "B+";
    else if (currentStudentGrade >= 83) currentStudentLetterGrade = "B";
    else if (currentStudentGrade >= 80) currentStudentLetterGrade = "B-";
    else if (currentStudentGrade >= 77) currentStudentLetterGrade = "C+";
    else if (currentStudentGrade >= 73) currentStudentLetterGrade = "C";
    else if (currentStudentGrade >= 70) currentStudentLetterGrade = "C-";
    else if (currentStudentGrade >= 67) currentStudentLetterGrade = "D+";
    else if (currentStudentGrade >= 63) currentStudentLetterGrade = "D";
    else if (currentStudentGrade >= 60) currentStudentLetterGrade = "D-";
    else currentStudentLetterGrade = "F";

    decimal score_exam = (decimal)notas / studentScores.Length;
    decimal points_extra = currentStudentGrade - score_exam;
    decimal credito = (score_exam + ((decimal)points_extra / 10m));
    System.Console.WriteLine($"{Student}\t\t\t{(score_exam).ToString("F2")}\t\t\t{currentStudentGrade}\t\t{currentStudentLetterGrade}\t\t{(credito).ToString("F2")} ({points_extra.ToString("F2")} pts)");
}

Console.WriteLine("\n\rPress the Enter key to continue");