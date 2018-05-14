using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CktMgr.CircuitLib
{
    public class CircuitRepoAdo : ICircuitRepo
    {
        private const string connStr = "Server=(localdb)\\mssqllocaldb;Database=gQuote;Trusted_Connection=True;MultipleActiveResultSets=true";

        private const string selectQuery = "Select Top 100 *\n" +
            "FROM MainCircuits\n";

        // public string addressClause = "Where Address LIKE '%@address%' \n";
        // private string cityClause = "And City Like '%@city%' ";
        // private string stateClause = "And State Like '%@state%' ";
        // private string zipClause = "And Zip Like '%@zip%'";

        private string searchClause1 = "Where Address Like @Address And City Like @City And State Like @State And Zip Like @Zip";

        private string pagingSearch = "Select Top 10 * From\n" +
                                      "(SELECT TOP 10 * From\n" +
                                      "(SELECT TOP ";

        // private string pagingSearch2 = " * From MainCircuitTable " +
        //                               "Where Address Like @Address And City Like @City And State = @State And Zip Like @Zip\n" +
        //                               "ORDER BY Id ASC) As Table1\n"+
        //                               "ORDER BY Id DESC) AS Table2\n"+
        //                               "ORDER BY Address ASC";
        private string pagingSearch2 = " * From MainCircuits " +
                              "Where Address Like @Address And City Like @City And State Like @State And Zip Like @Zip\n" +
                              "ORDER BY Id ASC) As Table1\n" +
                              "ORDER BY Id DESC) AS Table2\n" +
                              "ORDER BY Address ASC";

        // Reference Clause
        // Select Top 10 * From
        // (Select Top 10 * From
        // (SELECT TOP 30 * From MainCircuitTable
        // Where Address Like '%Wash%' And City Like '%Augus%' And State = 'GA'
        // ORDER BY Id ASC) AS Table1
        // ORDER By Id DESC) AS Table2
        // Order By Id ASC




        // private string addressClause2 = "@Address";
        // private string searchClause2 = "%' And City Like '%Macon%'";
        // @Address" %' \n And City Like '%Macon%' ";
        // And State Like '%@state%' And Zip Like '%@zip%'";


        private const string selectByCityClause = "Where City = 'Augusta'\n";
        private const string selectByTier = "And Tier = '2'\n";
        private const string orderByName = "ORDER BY City asc, State asc\n";
        private const string whereId = "Where Id = @Id\n";

        public List<Circuit> ListAll()
        {
            List<Circuit> circuits = new List<Circuit>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // ZZ what needs to go here to get out of an Augusta-pull
                SqlCommand command = new SqlCommand(selectQuery, conn);

                try
                {
                    conn.Open();  // database, open-up
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // var foo = reader.GetInt64(0);
                        Circuit newCircuit = new Circuit
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Region = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            City = reader[3].ToString(),
                            State = reader[4].ToString(),
                            Zip = reader[5].ToString(),
                            LAT = reader[6].ToString(),
                            LON = reader[7].ToString(),
                            DeliveryMethod = reader[8].ToString(),
                            Speed = reader[9].ToString(),
                            Term = reader[10].ToString(),
                            MRR = reader[11].ToString(),
                            NRR = reader[12].ToString()

                        };
                        circuits.Add(newCircuit);
                    }
                }
                catch (Exception ex)
                {
                    //TODO:  Log Errors
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return circuits;
        }
        public Circuit GetById(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                Circuit circuitToDetail = new Circuit();
                SqlCommand command = new SqlCommand(selectQuery + whereId, conn);
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    conn.Open();  // database, open-up
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        circuitToDetail.Id = int.Parse(reader[0].ToString());
                        circuitToDetail.Region = reader[1].ToString();
                        circuitToDetail.Address = reader[2].ToString();
                        circuitToDetail.City = reader[3].ToString();
                        circuitToDetail.State = reader[4].ToString();
                        circuitToDetail.Zip = reader[5].ToString();
                        circuitToDetail.LAT = reader[6].ToString();
                        circuitToDetail.LON = reader[7].ToString();
                        circuitToDetail.DeliveryMethod = reader[8].ToString();
                        circuitToDetail.Speed = reader[9].ToString();
                        circuitToDetail.Term = reader[10].ToString();
                        circuitToDetail.MRR = reader[11].ToString();
                        circuitToDetail.NRR = reader[12].ToString();

                    };
                }
                catch (Exception ex)
                {
                    //TODO:  Log Errors
                    Console.WriteLine(ex.Message);
                    throw;
                }
                return circuitToDetail;
            }
        }
        public List<Circuit> SearchAddress(SearchModel searchToComplete)
        {
            var addressString = "%"+ (string)searchToComplete.Address + "%";
            var cityString = "%" + (string)searchToComplete.City + "%";
            var stateString = "%" + (string)searchToComplete.State + "%";
            var zipString = "%" + (string)searchToComplete.Zip + "%";

            List<Circuit> circuits = new List<Circuit>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(selectQuery + searchClause1, conn);
                command.Parameters.AddWithValue("@Address", addressString);
                command.Parameters.AddWithValue("@City", cityString);
                command.Parameters.AddWithValue("@State", stateString);
                command.Parameters.AddWithValue("@Zip", zipString);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader(); // changed the order

                    while (reader.Read())
                    {
                        Circuit newCircuit = new Circuit
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Region = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            City = reader[3].ToString(),
                            State = reader[4].ToString(),
                            Zip = reader[5].ToString(),
                            LAT = reader[6].ToString(),
                            LON = reader[7].ToString(),
                            DeliveryMethod = reader[8].ToString(),
                            Speed = reader[9].ToString(),
                            Term = reader[10].ToString(),
                            MRR = reader[11].ToString(),
                            NRR = reader[12].ToString()

                        };
                        circuits.Add(newCircuit);
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                return circuits;
            }
        }

        // ZZZ rebuild with a new Query
        public List<Circuit> SearchAddressPageReturn(SearchModel searchToComplete, int pageNumber)
        {
            // On paging
            // ZZZ http:   //easyhtml5video.com/articles/bootstrap-pagination-demo-387.html
            var addressString = "%" + (string)searchToComplete.Address + "%";
            var cityString = "%" + (string)searchToComplete.City + "%";
            var stateString = "%" + (string)searchToComplete.State + "%";
            var zipString = "%" + (string)searchToComplete.Zip + "%";

            // pageNumber = 2;
            var numToPull = pageNumber * 10;
            var numToPullString = numToPull.ToString();

            // var pagingSearchTotal = pagingSearch + numToPullString + pagingSearch2;
            var pagingSearchTotal = pagingSearch + numToPullString + pagingSearch2;


            List<Circuit> circuits = new List<Circuit>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(pagingSearchTotal, conn);
                command.Parameters.AddWithValue("@Address", addressString);
                command.Parameters.AddWithValue("@City", cityString);
                command.Parameters.AddWithValue("@State", stateString);
                command.Parameters.AddWithValue("@Zip", zipString);
                // command.Parameters.AddWithValue("@numToPull", numToPullString);

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader(); // changed the order

                    while (reader.Read())
                    {
                        Circuit newCircuit = new Circuit
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Region = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            City = reader[3].ToString(),
                            State = reader[4].ToString(),
                            Zip = reader[5].ToString(),
                            LAT = reader[6].ToString(),
                            LON = reader[7].ToString(),
                            DeliveryMethod = reader[8].ToString(),
                            Speed = reader[9].ToString(),
                            Term = reader[10].ToString(),
                            MRR = reader[11].ToString(),
                            NRR = reader[12].ToString()

                        };
                        circuits.Add(newCircuit);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                return circuits;
            }
        }


        public void AddCircuit(Circuit newCircuit)
        {
            throw new NotImplementedException();
        }
    }
}
