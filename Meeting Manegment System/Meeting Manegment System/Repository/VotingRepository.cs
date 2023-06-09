﻿using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class VotingRepository :IVotingRepository
    {
        private ApplicationDbContext _context;
        public VotingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int GetMaxId()
        {
            return _context.Votings.Max(x => x.VotingId);
        }
        public Voting GetById(int id)
        {
            return _context.Votings.FirstOrDefault(x => x.VotingId == id);
        }
        public List<Voting> GetAllVotingsByMeetingId(int id)
        {
            return _context.Votings.Where(x=>x.MeetingId == id).ToList();
        }
        public bool Add(Voting voting)
        {
            _context.Add(voting);
            return Save();
        }

        public bool Delete(Voting voting)
        {
            _context.Remove(voting);
            return Save();
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Voting voting)
        {
            _context.Update(voting);
            return Save();
        }
    }
}
