using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CubeHelper.Models
{
    public class CardDBHelper
    {

        private static string[] jsonFaceProperties = new string[] {"name", "type_line", "oracle_text", "mana_cost", "power", "toughness", "loyalty"};
        private static string[] jsonCardProperties = new string[] {"name", "cmc", "color_identity", "layout"};

        //Special Cases: Who // What // When // Where // Why, Brisela, Hanweir, Chittering Host
        public static dynamic[] GetAllCardsJson()
        {
            throw new NotImplementedException();
            //Should return an array of json objects for all magic cards.
        }

        public static void ReloadDB()
        {
            dynamic[] allCards = GetAllCardsJson();
            List<dynamic> formattedCards = new List<dynamic>();

            foreach(dynamic card in allCards){

                string layout = card.layout;
                List<dynamic> newFaces = new List<dynamic>();

                if(layout == "split" || layout == "flip" || layout == "transform")
                {
                    for(int i = 0; i < card.card_faces.Count)
                    {
                        dynamic jsonCardFace = card.card_faces[0];
                        dynamic formattedFace = GetFormattedJObject(jsonCardFace, jsonFaceProperties);
                        formattedFace.face_index = i;
                        newFaces.Add(formattedFace);
                    }
                } else {
                    dynamic formattedFace = GetFormattedJObject(jsonCardFace, jsonFaceProperties);
                    formattedFace.face_index = 0;
                    newFaces.Add(formattedFace);
                }

                dynamic newCard = new Newtonsoft.Json.Linq.JObject();
                newCard.faces = newFaces.ToArray();
                newCard.name = card.name;
                newCard.cmc = (int)((float)card.cmc);
                newCard.color_identity = string.Join("", card.color_identity.ToObject<string[]>());
                newCard.layout = layout;
                formattedCards.Add(newCard);
            }

            MySqlConnection conn = DB.Connection();
            conn.Open();

            foreach(dynamic card in formattedCards)
            {
                //write card to db
            }
        }

        private static dynamic GetFormattedJObject(dynamic obj, string[] properties)
        {
            dynamic newObject = new Newtonsoft.Json.Linq.JObject();

            foreach(string prop in properties)
            {
                if(obj[prop] != null)
                {
                    newObject[prop] = obj[prop];
                } else {
                    newObject[prop] = "null";
                }
            }

            return newObject;
        }

        public static void RepopulateCards()
        {
            dynamic[] allCards = GetAllCardsJson();

            //write all cards to DB.cards

            //write all card faces to db.faces
        }
    }
}
