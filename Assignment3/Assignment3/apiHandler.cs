using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract]
    class Tournament {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        public Tournament(string name) {
            this.name = name;
        }
    }
    [DataContract]
    class Team {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        public Team(string name)
        {
            this.name = name;
        }
        public Team() { }
    }

    [DataContract]
    class Player
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        public Player(string name)
        {
            this.name = name;
        }
    }

    [DataContract]
    class Match
    {
        [DataMember]
        public string id { get; protected set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string number { get; set; }
        public Match(string type, string number)
        {
            this.type = type;
            this.number = number;
        }
    }

    [DataContract]
    class Score
    {
        [DataMember]
        public string data { get; set; }
        public Score(string data)
        {
            this.data = data;
        }
    }

    class ApiHandler
    {
        public async static Task<string> addTournament(Tournament tournament) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=add&type=tournament&name=" + tournament.name);
            

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tournament));
            serializer.WriteObject(stream, tournament);
            
            HttpContent content = new StreamContent(stream);

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
            stream.Close();

            response.EnsureSuccessStatusCode();
            string result = await (response.Content.ReadAsStringAsync());

            Console.WriteLine(result);
            return result;
        }

        public async static Task<string> addTeam(string tournamentID, Team team) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=add&type=team&tournament=" + tournamentID + "&name=" + team.name);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Team));
            serializer.WriteObject(stream, team);
            
            HttpContent content = new StreamContent(stream);

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
            stream.Close();

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            return result;
        }

        public async static Task<string> addPlayer(string teamID, Player player)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=add&type=player&team=" + teamID + "&name=" + player.name);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Player));
            serializer.WriteObject(stream, player);
            
            HttpContent content = new StreamContent(stream);

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
            stream.Close();

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            return result;
        }
        public async static Task<string> addTeamToMatch(Match match)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=add&type=matchresult&tournament=313&team=592&matchtype=" + match.type +"&matchnumber=" + match.number +"&score=87");
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Match));
            serializer.WriteObject(stream, match);
            
            HttpContent content = new StreamContent(stream);

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
            stream.Close();

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            return result;
        }

        public async static Task<string> updateScore(Score score)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=add&type=matchresult&tournament=313&team=592&matchtype=qual&matchnumber=1&score=" + score.data);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Score));
            serializer.WriteObject(stream, score);
            HttpContent content = new StreamContent(stream);

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
            stream.Close();

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            return result;
        }

        public static T jsonTo<T>(String jStr) {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jStr));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            T result = (T)ser.ReadObject(stream);
            stream.Close();
            return result;
        }

       

        public async static Task<string> getTeams(string tournamentID) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=teams&tournament=" + tournamentID +"&format=json");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            string result = await response.Content.ReadAsStringAsync();
            result = result.Substring(10);
            Console.WriteLine(result);
            return result;
        }

        public async static Task<string> getPlayers(string teamID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://partiklezoo.com/aerialassist/index.php?action=players&team=" + teamID + "&format=json");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            string result = await response.Content.ReadAsStringAsync();
            result = result.Substring(11);
            Console.WriteLine(result);
            return result;
        }


    }
}
