using Domain.Domain.Enums;
using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Animals
{
    public class RemovedAnimalDB : IAnimalDB
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddAnimal(Animal a, int b)
        {
            string command = "INSERT INTO `zb_removedanimals`(`idAuto`, `Name`, `Species`, `EnterDate`, `Origin`, `Gender`, `DateOfBirth`, `Diet`, `LeavingDate`, `LeavingReason`, `Notes`, `ID`, `Relations`, `ExhibitID`, `IsPredator`, `IsPrey`, `EnvironmentType`, `LeavingMode`) VALUES (NULL,@name,@species,@enterDate,@origin,@gender,@dateOfBirth,@diet,@leavingDate,@leavingReason,@notes,@ID,@relations,@exhibitID,@isPredator,@isPrey, @enviromentType, @leavingmode)";
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
				add.Parameters.AddWithValue("@enviromentType", a.AnimalEnviroment);
                add.Parameters.AddWithValue("@leavingmode", b);
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
            string command = "DELETE FROM `zb_removedanimals` WHERE idAUto = @idAuto";
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
                    int zoneID = reader.GetInt32("ZoneId");
                    exhibit = new Exhibit(name, predatorOrPrey, enviromentType, zoneID);
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
        public List<Animal> GetBySpecies(AnimalSpecies species)
        {
            List<Animal> results = new List<Animal>();



            string command = "SELECT * FROM `zb_removedanimals` WHERE Species = @species";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("species", species.ToString());
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
                    EnviromentType animalEnviroment = (EnviromentType)reader.GetInt32("EnviromentType");
                    int feedingPeriod = reader.GetInt32("FeedingPeriod");
                    FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");

                    results.Add(new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, animalEnviroment, leavingDate, leavingReason,feedingPeriod, preferedSlot));
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

        public List<Animal> ReadAllAnimals()
        {
            List<Animal> results = new List<Animal>();



            string command = "SELECT * FROM `zb_removedanimals`";
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
                    EnviromentType animalEnviroment = (EnviromentType)reader.GetInt32("EnviromentType");
                    int feedingPeriod = reader.GetInt32("FeedingPeriod");
                    FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");
                    results.Add(new Animal(idAuto, name, species, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, animalEnviroment, leavingDate, leavingReason, feedingPeriod, preferedSlot));
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

        public void UpdateAnimal(Animal a)
        {
            string command = "UPDATE `zb_removedanimals` SET `Name`=@name,`Species`=@species,`EnterDate`=@enterDate,`Origin`=@origin,`Gender`=@gender,`DateOfBirth`=@dateOfBirth,`Diet`=@diet,`LeavingDate`=@leavingDate,`LeavingReason`=@leavingReason,`Notes`=@notes,`ID`=@ID,`Relations`=@relations,`ExhibitID`=@exhibitID,`IsPredator`=@isPredator,`IsPrey`=@isPrey, `EnviromentType`=@enviromentType WHERE idAuto = @idAuto";
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
				add.Parameters.AddWithValue("@enviromentType", a.AnimalEnviroment);
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

        public List<Animal> GetByExhibit(Exhibit exhibit)
        {
            throw new NotImplementedException();
        }

        public Animal GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}