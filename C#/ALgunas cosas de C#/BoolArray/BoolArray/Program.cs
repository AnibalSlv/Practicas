bool VisiblePant = true;
bool VisiblePreg, VisibleFamily, VisibleLab, VisiblePhyE, VisibleCond, VisibleDiag = false;
int n = 0;

bool[] visible = new bool[7];

Console.WriteLine("x");
n = int.Parse(Console.ReadLine());

VisiblePant = visible[0];
VisiblePreg = visible[1];
VisibleFamily = visible[2];
VisibleLab = visible[3];
VisiblePhyE = visible[4];
VisibleCond = visible[5];
VisibleDiag = visible[6];

for (int i = 0; i < visible.Length; i++)
{
    Console.WriteLine(visible[i]);
}