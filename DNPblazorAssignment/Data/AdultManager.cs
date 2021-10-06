using System;
using System.Collections.Generic;
using System.Linq;
using FileData;
using Models;

namespace DNPblazorAssignment.Data
{
    
    public class AdultManager : IAdultManager
    {
        private FileContext fileContext;
        private IList<Adult> adults;
        
        public AdultManager()
        {
            fileContext = new FileContext();
            adults = fileContext.Adults;
        }
        
        public void AddAdult(Adult adult)
        {
            int max;
            try
            {
                max = adults.Max(ad => ad.Id);
            }
            catch (InvalidOperationException)
            {
                max = 1;
            }
            
            adult.Id += ++max;
            adults.Add(adult);
            fileContext.SaveChanges();
        }

        public void RemoveAdult(int id)
        {
            adults.Remove(GetAdult(id));
            fileContext.SaveChanges();
        }

        public void UpdateAdult(Adult adult)
        {
            Adult toUpdate = GetAdult(adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.HairColor = adult.HairColor;
            fileContext.SaveChanges();
        }

        public Adult GetAdult(int id)
        {
            return adults.First(ad => ad.Id == id);
        }

        public IList<Adult> GetAll()
        {
            return new List<Adult>(adults);
        }
    }
}