using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Connections;
using zooproject.Domain.Domain.Exceptions;
using Domain.Domain.Exceptions;
using Domain.Domain.Enums;

namespace zooproject.Infrastructure.Databases.Animals
{
    public class AnimalDB : IAnimalDB
    {
        Connection connection = new Connection();
        public void AddAnimal(Animal a, int b)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "INSERT INTO `zb_animals`(`idAuto`, `Name`, `Species`, `EnterDate`, `Origin`, `Gender`, `DateOfBirth`, `Diet`, `LeavingDate`, `LeavingReason`, `Notes`, `ID`, `Relations`, `ExhibitID`, `IsPredator`, `IsPrey`, `EnviromentType`,`FeedingPeriod`,`PreferedSlot`) VALUES (NULL,@name,@species,@enterDate,@origin,@gender,@dateOfBirth,@diet,@leavingDate,@leavingReason,@notes,@ID,@relations,@exhibitID,@isPredator,@isPrey,@enviromentType,@feedingPeriod,@preferedSlot)";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
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
                    add.Parameters.AddWithValue("@feedingPeriod", a.FeedingPeriod);
                    add.Parameters.AddWithValue("@preferedSlot", a.PreferedSlot);
                    MySqlDataReader reader = add.ExecuteReader();
                }
                //TODO: work on proper exhceptions
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public void DeleteAnimal(Animal a)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "DELETE FROM `zb_animals` WHERE idAUto = @idAuto";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
                    add.Parameters.AddWithValue("@idAuto", a.IDAuto);
                    MySqlDataReader reader = add.ExecuteReader();
                }
                //TODO: work on proper exhceptions
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public List<Animal> ReadAllAnimals()
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Animal> results = new List<Animal>();
                string command = "SELECT * FROM `zb_animals`";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                        EnviromentType enviromentType = (EnviromentType)reader.GetInt32("EnviromentType");
                        int feedingPeriod = reader.GetInt32("FeedingPeriod");
                        FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");
                        results.Add(new Animal(idAuto, name, species, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, enviromentType, leavingDate, leavingReason,feedingPeriod,preferedSlot));
                    }
                }
                //TODO: work on proper exhceptions
                catch(SqlException Ex)
                {
                    Console.WriteLine(Ex);
                    throw new NoConnectionException(Ex.Message);
                }
                return results;
            }
        }
        public Exhibit GetExhibit(int id)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                Exhibit exhibit = null;
                string command = "SELECT * FROM `zb_exhibit` WHERE id = @id";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                }
                catch
                {
                    //TODO: work on proper exhceptions
                }

                return exhibit;
            }
        }
        public void UpdateAnimal(Animal a)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "UPDATE `zb_animals` SET `Name`=@name,`Species`=@species,`EnterDate`=@enterDate,`Origin`=@origin,`Gender`=@gender,`DateOfBirth`=@dateOfBirth,`Diet`=@diet,`LeavingDate`=@leavingDate,`LeavingReason`=@leavingReason,`Notes`=@notes,`ID`=@ID,`Relations`=@relations,`ExhibitID`=@exhibitID,`IsPredator`=@isPredator,`IsPrey`=@isPrey, `EnviromentType`=@enviromentType, `FeedingPeriod`=@feedingPeriod,`PreferedSlot`=@preferedSlot WHERE idAuto = @idAuto";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
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
                    add.Parameters.AddWithValue("@enviromentType", a.AnimalEnviroment);
                    add.Parameters.AddWithValue("@feedingPeriod", a.FeedingPeriod);
                    add.Parameters.AddWithValue("@preferedSlot", a.PreferedSlot);
                    MySqlDataReader reader = add.ExecuteReader();
                }
                //TODO: work on proper exhceptions
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public List<Animal> GetBySpecies(AnimalSpecies species)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Animal> results = new List<Animal>();
                string command = "SELECT * FROM `zb_animals` WHERE Species = @species";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                        EnviromentType enviromentType = (EnviromentType)reader.GetInt32("EnviromentType");
                        int feedingPeriod = reader.GetInt32("FeedingPeriod");
                        FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");
                        results.Add(new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, enviromentType, leavingDate, leavingReason, feedingPeriod, preferedSlot));
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return results;
            }
        }
        public List<Animal> GetByExhibit(Exhibit exhibit)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Animal> results = new List<Animal>();
                string command = "SELECT * FROM `zb_animals` WHERE ExhibitID = @exhibitID";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                        EnviromentType enviromentType = (EnviromentType)reader.GetInt32("EnviromentType");
                        int feedingPeriod = reader.GetInt32("FeedingPeriod");
                        FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");
                        results.Add(new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, id, relations, exhibitID, isPredator, isPrey, enviromentType, leavingDate, leavingReason, feedingPeriod, preferedSlot));
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return results;
            }
        }
        public Animal GetByID(int id)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                Animal result = null;
                string command = "SELECT * FROM `zb_animals` WHERE idAuto = @id";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                        EnviromentType enviromentType = (EnviromentType)reader.GetInt32("EnviromentType");
                        int feedingPeriod = reader.GetInt32("FeedingPeriod");
                        FeedingTimeSlot preferedSlot = (FeedingTimeSlot)reader.GetInt32("PreferedSlot");
                        result = new Animal(idAuto, name, resultSpecies, enterDate, origin, animalGender, dateOfBirth, diet, notes, idResult, relations, exhibitID, isPredator, isPrey, enviromentType, leavingDate, leavingReason, feedingPeriod, preferedSlot);
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return result;
            }
        }
    }
}