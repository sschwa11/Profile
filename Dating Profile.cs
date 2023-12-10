using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Personality.MeyersBriggs;
using Personality.Nerd;
using CulinaryArts;
using Relationships;
using FamilyRelations;

namespace OKC {
	public class Scott {
		public bool AllowHeadOnChest {get; private set; }
		public bool BagelAppreciation { get; private set; }
		public bool IsJewish { get; private set; }
		
		public string CurrentState { get; public set; }
		public string Name { get; private set; }
		public bool LovesAnimals { get; private set; }
		public string LoveLanguage { get; private set; }
		public string Profession { get; private set; }
		
		public List<string> BonusSkills { get; private set; }	
		public Family FamilyRelationships { get; private set; }
		
		public Scott() {
			Name = "Scott";
			Profession = "Software Engineer";
			IsJewish = true;
			LovesAnimals = true;
			LoveLanguage = "Python";
			BagelAppreciation = IsBagelAppreciationGenuine();
			FamilyRelationships = new Family { Mother = true, Father = true, YoungerBrother = true };
			BonusSkills = new List<string> { "Various Life Skills", "Cooking", "Musician", "RubiksCuber", "Electronics Repair"};
		}
		
		public bool IsBagelAppreciationGenuine {
			if (IsJewish && GetState() == "NY") {
				if (Religion.Judaism.JudgeBagel(Bagel) >= 9 && Bagel.Quality >= 9) {
					return true;
				}
			}
			
			return false;
		}
		
		public bool CheckState() {
			if (CurrentState == "Cuddling")
			AllowHeadOnChest == true;
		}
		
		public void Promises(person You) {
			You.Feelings["Safe"] = true;
			You.Feelings["Loved"] = true;
		
			foreach (Interest i in You.Interests) {
			Nerd.NerdOut(i);
			}
		}
		
		public string async Task GetState() {
			string API_KEY = "AIzaSyBjGsYwceG1WhHsMiemczm-qHW1q4mK3KQ";
			HttpClient client = new HttpClient();
			
			var response = await client.GetStringAsync($"https://maps.googleapis.com/maps/api/geocode/json?latlng=40.78961859009391,-73.50815782552499&key={API_KEY}");
			
				using (JsonDocument document = JsonDocument.Parse(response)) {
					JsonElement root = document.RootElement;
					string state = root.GetProperty("results")[0].GetProperty("formatted_address").ToString().Split(',')[2].Trim().Substring(0, 2);
					Console.WriteLine(state);
				}
			}
		}
	}
}
