using System;
using System.Collections.Generic;
namespace zadaca1ml {
	public abstract class Osoba
	{
		public string Ime { get; set; };
		public string prezime { get; set; };
		public int Id { get; set; };

		public Osoba(string ime, string prezime, int id)
		{
			this.Ime = ime;
			this.Prezime = prezime;
			this.Id = id;
		} 
	}

		public class Student : Osoba {
			public List<int>() Ocjene;
			public int Razred;

			public Student(string ime, string prezime, int id, int razred) : base(ime, prezime, id) {
				this.Razred = razred;
			    Ocjene = new List<string>();
			}

			public void DodajOcjene(int ocjena)
			{
				this.ocjene.Add(ocjena);
			}

			public void PrikaziOcjene()
			{
				Console.WriteLine("Ocjene učenika:"{ Ime}
				{ Prezime} "su:"{ string.Join(ocjene)}
			}

		}
	public class Ucitelj : Osoba
	{
		public List<string> PredmetiKojePredaje { get; set; }

		public Ucitelj(string ime,string prezime,int id,List<string> predmetiKojePredaje):base(ime, prezime, id)
		{
			PredmetiKojePredaje = predmetiKojePredaje;
		}
		public void DodavanjeOcjenaStudentima(Student student,int ocjena) {
			student.DodajOcjene(ocjena);
		}
		public void PregledajOcjeneStudentu(Student student) {
			student.PrikaziOcjene;
		}

	}

	public class Ravnatelj : Osoba
	{
		public List<string> Ucitelji { get; set; };
		public List<string> Studenti { get; set; };
		public Ravnatelj(string ime,string prezime,string id):base(ime, prezime, id)
		{

		}

		public void DodajUcitelja(Ucitelj ucitelj)
		{
			Ucitelji.Add(ucitelj);
				
		}
        public void DodajStudenta(Student student)
        {
            Studenti.Add(student);

        }
        public void UkloniUcitelja(Ucitelj ucitelj) { 	
		Ucitelji.Remove(ucitelj);	
		}
        public void UkloniStudenta(Student student)
        {
            Studenti.Remove(student);
        }
		public void PregleOpcihOcjena(){
			foreach(var student in Studenti)
			{
				student.PrikaziOcjena();
			}
		}


    }
	public class Razred
	{
		public string naziv { get; set; };
		public List<Student> Studenti { get; set; };

		public Razred(string naziv,List<Student> studenti)
		{
			naziv = naziv;
			studenti = new List<Student>();
		}
		public void DodajStudente(Student student)
		{
			Studenti.Add(student);
		}
		public void UkloniStudente(Student student)
		{
			Studenti.Remove(student);	
		}
		public void PrikaziOcjene(Razred razred)
		{
			foreach(Student student in Studenti) {
			student.PrikaziOcjene()
			}
		}
	}

	class Program
	{
		static void Main()
		{
			Ravnatelj ravnatelj = new Ravnatelj("Ivan", "Ravnatelj", 1);

			Ucitelj ucitelj = new Ucitelj("Marko", "Ucitelj", 2, new List<string>("Engleski", "Hrvatski");
			ravnatelj.DodajUcitelja(ucitelj);

			Student student = new Student("Mihael", "Lackovic", 66, 1);
			ravnatelj.DodajStudenta(student);

			Razred razred = new Razred("3C");
			razred.DodajStudente(student);

			ucitelj.DodavanjeOcjenaStudentima(student, 2);
			ucitelj.PregledajOcjeneStudentu(student);

			ravnatelj.PregleOpcihOcjena();



					

		}
	}


}