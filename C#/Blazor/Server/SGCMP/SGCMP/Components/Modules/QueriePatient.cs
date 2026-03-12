namespace SGCMP.Components.Modules;

public class QueriePatient
{
    public string NameChild {get; set;}
    public int Age {get; set;}
    public string Consult {get; set;}
    public string NameRepresentative {get; set;}
    public double Telephone {get; set;}
    public DateTime DateT {get; set;}
    public int Income {get; set;}
    public string TypeIncome {get; set;}
        
    public QueriePatient(string nameChild, int age, string consult,string nameRepresentative, double telephone, DateTime dateT, int income, string typeIncome)
    {
    	this.NameChild = nameChild;
    	this.Age = age;
    	this.Consult = consult;
    	this.NameRepresentative = nameRepresentative;
    	this.Telephone = telephone;
    	this.DateT = dateT;
    	this.Income = income;
    	this.TypeIncome = typeIncome;
    }
}