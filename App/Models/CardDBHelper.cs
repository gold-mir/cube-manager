using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CubeHelper.Models
{
    public class CardDBHelper
    {
        //Special Cases: Who // What // When // Where // Why, Brisela, Hanweir, Chittering Host
        public static dynamic[] GetAllCardsJson()
        {
            throw new NotImplementedException();
            //Should return an array of json objects for all magic cards.
        }

        public static void GetCardObjectsArray()
        {
            dynamic[] allCards = GetAllCardsJson();
            string[] allFacesData


            foreach(dynamic card in allCards){
                string cardName = card.name;
                string oid = card.oracle_id;

                string layout = card.layout;

                dynamic cardObject = new System.Dynamic.ExpandoObject();

                if(layout == "split" || layout == "transform")
                {
                    int faceCount = card.faces.Count;
                    card.faces = new dynamic[faceCount];
                    for(int i = 0; i < faceCount; i++)
                    {
                        faces[0]
                    }
                } else
                {
                    card.faces = new dynamic {new System.Dynamic.ExpandoObject()};
                }
            }
        }

        public static void RepopulateCards()
        {
            dynamic[] allCards = GetAllCardsJson();

            //write all cards to DB.cards

            //write all card faces to db.faces
        }
    }
}
