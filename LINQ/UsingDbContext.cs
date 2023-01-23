using LINQ.EntityFramework;
using LINQ.EntityFramework.Escola;

namespace LINQ
{
    internal class UsingDbContext
    {

        public static IEnumerable<UserModel> GetAllUsers() {
            using (var context = new SqlServerContext())
            {
                return context.Users.ToList();
            }
        }

        public static void RegisterUser(string name, string email)
        {
            using (var context = new SqlServerContext())
            {

                var checkUser = context.Users.Where(u => u.Email == email || u.Name == name).FirstOrDefault();
                if (checkUser != null) return;

                var newUser = new UserModel { Name = name, Email = email };
                context.Users.Add(newUser);
                context.SaveChanges();

                Console.WriteLine($"Usuário {name} foi criado.");
            }
        }

        public static void AdicionarNovoAluno(string nome)
        {
            using (var context = new SqlServerContext())
            {

                var checkUser = context.Materias.FirstOrDefault(m => m.Nome== nome);
                if (checkUser != null) return;

                AlunoModel alunoNovo = new AlunoModel { Nome = nome, Materias = new List<MateriaModel>() };

                context.Add(alunoNovo);
                context.SaveChanges();
                
            }

        }

        public static void AdicionarAlunoEmRedes(int AlunoId, string nomeMateria) {
            using (var context = new SqlServerContext())
            {

                var MateriaRedes = context.Materias.FirstOrDefault(m => m.Nome == nomeMateria);
                if (MateriaRedes == null) return;

                var aluno = context.Alunos.FirstOrDefault(a => a.AlunoId== AlunoId);
                if (aluno == null) return;

                if(aluno.Materias == null)
                    aluno.Materias = new List<MateriaModel>();
                
                if (MateriaRedes.Alunos == null)
                    MateriaRedes.Alunos = new List<AlunoModel>();


                MateriaRedes.Alunos.Add(aluno);
                aluno.Materias.Append(MateriaRedes);

                context.SaveChanges();

            }
        }

    }
}

