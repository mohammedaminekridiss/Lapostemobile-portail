using System;
using System.Collections.Generic;
using System.Linq;
using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Repositories
{
    public class AdresseRepository
    {
        private readonly PortailContext _context;

        public AdresseRepository(PortailContext context)
        {
            _context = context;
        }

        public IEnumerable<Adresse> GetAll()
        {
            return _context.Adresses.ToList();
        }

        public Adresse GetById(int id)
        {
            return _context.Adresses.Find(id);
        }

        public void Add(Adresse adresse)
        {
            _context.Adresses.Add(adresse);
            _context.SaveChanges();
        }

        public void Update(Adresse adresse)
        {
            _context.Entry(adresse).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var adresse = _context.Adresses.Find(id);
            if (adresse == null)
            {
                return false; // Adresse non trouvée
            }

            _context.Adresses.Remove(adresse);
            _context.SaveChanges();
            return true; // Suppression réussie
        }
    }
}
