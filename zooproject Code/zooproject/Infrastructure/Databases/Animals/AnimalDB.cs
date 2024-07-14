using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Exhibits;

namespace zooproject.Infrastructure.Databases.Animals
{
    public class AnimalDB : IAnimalDB
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddAnimal(Animal a)
        {
            string command = "INSERT INTO `zb_animals`(`idAuto`, `Name`, `Species`, `EnterDate`, `Origin`, `Gender`, `DateOfBirth`, `Diet`, `LeavingDate`, `LeavingReason`, `Notes`, `ID`, `Relations`, `ExhibitID`, `IsPredator`, `IsPrey`) VALUES (NULL,@name,@species,@enterDate,@origin,@gender,@dateOfBirth,@diet,@leavingDate,@leavingReason,@notes,@ID,@relations,@exhibitID,@isPredator,@isPrey)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", a.Name);
                add.Parameters.AddWithValue("@species", Convert.ToInt32(a.Species));
                add.Parameters.AddWithValue("@enterDate", a.EnterDate);
                add.Parameters.AddWithValue("@origin", a.Origin);
                add.Parameters.AddWithValue("@gender", Convert.ToInt32(a.AnimalGender));
                add.Parameters.AddWithValue("@dateOfBirth", a.DateOfBirth);
                add.Parameters.AddWithValue("@diet", a.Diet);
                add.Parameters.AddWithValue("@leavingDate", a.LeavingDate);
                add.Parameters.AddWithValue("@leavingReason", a.LeavingReason);
                add.Parameters.AddWithValue("@notes", a.Notes);
                add.Parameters.AddWithValue("@ID", a.ID);
                add.Parameters.AddWithValue("@relations", a.Relations);
                add.Parameters.AddWithValue("@exhibitID", a.exhibitID);
                add.Parameters.AddWithValue("@isPredator", a.IsPredator);
                add.Parameters.AddWithValue("@isPrey", a.IsPrey);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteAnimal(Animal a)
        {
            string command = "DELETE FROM `zb_animals` WHERE idAUto = @idAuto";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@idAuto", a.IDAuto);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Animal> ReadAllAnimals()
        {
            List<Animal> results = new List<Animal>();



            string command = "SELECT * FROM `zb_animals`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idAuto = reader.GetInt32("idAuto");
                    string name = reader.GetString("Name");
                    AnimalSpecies species = (AnimalSpecies)reader.GetInt32("Species");
                    DateTime enterDate = reader.GetDateTime("EnterDate");
                    string origin = reader.GetString("Origin");
                    Gender animalGender = (Gender)reader.GetInt32("Gender");
                    DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                    string diet = reader.GetString("Diet");
                    DateTime leavingDate = reader.GetDateTime("LeavingDate");
                    string leavingReason = reader.GetString("LeavingReason");
                    string notes = reader.GetString("Notes");
                    string id = reader.GetString("ID");
                    string relations = reader.GetString("Relations");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    bool isPredator = reader.GetBoolean("IsPredator");
                    bool isPrey = reader.GetBoolean("IsPrey");


                    results.Add(new Animal(idAuto, name, species, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, leavingDate, leavingReason));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return results;
        }
        public Exhibit GetExhibit(int id)
        {

            Exhibit exhibit = null;

            string command = "SELECT * FROM `zb_exhibit` WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("Name");
                    bool predatorOrPrey = reader.GetBoolean("PredatorOrPrey");
                    EnviromentType enviromentType = (EnviromentType)reader.GetInt32("ExhibitType");
                    exhibit = new Exhibit(name, predatorOrPrey, enviromentType);
                }
                //product = new Product(Name, Price);
            }
            catch
            {
                //TODO: work on proper exhceptions
            }
            finally
            {
                conn.Close();
            }



            return exhibit;
        }
        public void UpdateAnimal(Animal a)
        {
            string command = "UPDATE `zb_animals` SET `Name`=@name,`Species`=@species,`EnterDate`=@enterDate,`Origin`=@origin,`Gender`=@gender,`DateOfBirth`=@dateOfBirth,`Diet`=@diet,`LeavingDate`=@leavingDate,`LeavingReason`=@leavingReason,`Notes`=@notes,`ID`=@ID,`Relations`=@relations,`ExhibitID`=@exhibitID,`IsPredator`=@isPredator,`IsPrey`=@isPrey WHERE idAuto = @idAuto";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", a.Name);
                add.Parameters.AddWithValue("@species", Convert.ToInt32(a.Species));
                add.Parameters.AddWithValue("@enterDate", a.EnterDate);
                add.Parameters.AddWithValue("@origin", a.Origin);
                add.Parameters.AddWithValue("@gender", Convert.ToInt32(a.AnimalGender));
                add.Parameters.AddWithValue("@dateOfBirth", a.DateOfBirth);
                add.Parameters.AddWithValue("@diet", a.Diet);
                add.Parameters.AddWithValue("@leavingDate", a.LeavingDate);
                add.Parameters.AddWithValue("@leavingReason", a.LeavingReason);
                add.Parameters.AddWithValue("@notes", a.Notes);
                add.Parameters.AddWithValue("@ID", a.ID);
                add.Parameters.AddWithValue("@relations", a.Relations);
                add.Parameters.AddWithValue("@exhibitID", a.exhibitID);
                add.Parameters.AddWithValue("@isPredator", a.IsPredator);
                add.Parameters.AddWithValue("@isPrey", a.IsPrey);
                add.Parameters.AddWithValue("@idAuto", a.IDAuto);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }


        public List<Animal> GetBySpecies(AnimalSpecies species)
        {
            List<Animal> results = new List<Animal>();



            string command = "SELECT * FROM `zb_animals` WHERE Species = @species";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@species", Convert.ToInt32(species));
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idAuto = reader.GetInt32("idAuto");
                    string name = reader.GetString("Name");
                    AnimalSpecies resultSpecies = (AnimalSpecies)reader.GetInt32("Species");
                    DateTime enterDate = reader.GetDateTime("EnterDate");
                    string origin = reader.GetString("Origin");
                    Gender animalGender = (Gender)reader.GetInt32("Gender");
                    DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                    string diet = reader.GetString("Diet");
                    DateTime leavingDate = reader.GetDateTime("LeavingDate");
                    string leavingReason = reader.GetString("LeavingReason");
                    string notes = reader.GetString("Notes");
                    string id = reader.GetString("ID");
                    string relations = reader.GetString("Relations");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    bool isPredator = reader.GetBoolean("IsPredator");
                    bool isPrey = reader.GetBoolean("IsPrey");


                    results.Add(new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, leavingDate, leavingReason));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return results;
        }

        public List<Animal> GetByExhibit(Exhibit exhibit)
        {
            List<Animal> results = new List<Animal>();



            string command = "SELECT * FROM `zb_animals` WHERE ExhibitID = @exhibitID";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("exhibitID", exhibit.Id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idAuto = reader.GetInt32("idAuto");
                    string name = reader.GetString("Name");
                    AnimalSpecies resultSpecies = (AnimalSpecies)reader.GetInt32("Species");
                    DateTime enterDate = reader.GetDateTime("EnterDate");
                    string origin = reader.GetString("Origin");
                    Gender animalGender = (Gender)reader.GetInt32("Gender");
                    DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                    string diet = reader.GetString("Diet");
                    DateTime leavingDate = reader.GetDateTime("LeavingDate");
                    string leavingReason = reader.GetString("LeavingReason");
                    string notes = reader.GetString("Notes");
                    string id = reader.GetString("ID");
                    string relations = reader.GetString("Relations");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    bool isPredator = reader.GetBoolean("IsPredator");
                    bool isPrey = reader.GetBoolean("IsPrey");


                    results.Add(new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, leavingDate, leavingReason));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return results;
        }

        public Animal GetByID(int id)
        {
            Animal result = null;
            string command = "SELECT * FROM `zb_animals` WHERE idAuto = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idAuto = reader.GetInt32("idAuto");
                    string name = reader.GetString("Name");
                    AnimalSpecies resultSpecies = (AnimalSpecies)reader.GetInt32("Species");
                    DateTime enterDate = reader.GetDateTime("EnterDate");
                    string origin = reader.GetString("Origin");
                    Gender animalGender = (Gender)reader.GetInt32("Gender");
                    DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                    string diet = reader.GetString("Diet");
                    DateTime leavingDate = reader.GetDateTime("LeavingDate");
                    string leavingReason = reader.GetString("LeavingReason");
                    string notes = reader.GetString("Notes");
                    string idResult = reader.GetString("ID");
                    string relations = reader.GetString("Relations");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    bool isPredator = reader.GetBoolean("IsPredator");
                    bool isPrey = reader.GetBoolean("IsPrey");


                    result = new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, idResult, relations, exhibitID, isPredator, isPrey, leavingDate, leavingReason);
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}