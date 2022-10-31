using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DB.DBOperations;
using MyApp.Models;


namespace MyApp.DB.DBOperations
{
    public class TrainerRepository
    {
        public int AddTrainer(TrainerModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                Trainer tra = new Trainer()
                {
                    TrainerId = model.TrainerId,
                    TrainerName = model.TrainerName,
                    Gender = model.Gender,
                    Experience = model.Experience
                };

                context.Trainers.Add(tra);

                context.SaveChanges();

                return tra.TrainerId;
            }
        }

        public List<TrainerModel> GetAllTrainers()
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.Trainers.Select(x => new TrainerModel()
                {
                    TrainerId = x.TrainerId,
                    TrainerName = x.TrainerName,
                    Gender = x.Gender,
                    Experience = x.Experience
                }).ToList();
                return result;
            }
        }
        public TrainerModel GetTrainer(int TrainerId)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var result = context.Trainers
                    .Where(x => x.TrainerId == TrainerId)
                    .Select(x => new TrainerModel()
                    {
                        TrainerId=x.TrainerId,
                        TrainerName=x.TrainerName,
                        Gender=x.Gender,
                        Experience=x.Experience
                    }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateTrainer(int TrainerId, TrainerModel model)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var trainer = context.Trainers.FirstOrDefault(x => x.TrainerId == TrainerId);
                if (trainer != null)
                {
                    trainer.TrainerName = model.TrainerName;
                    trainer.Gender = model.Gender;
                    trainer.Experience = model.Experience;
                }
                context.Entry(trainer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }


        public bool TrainerDelete(int TrainerID)
        {
            using (var context = new sumatrain_dbEntities())
            {
                var trainer = new Trainer()
                {
                    TrainerId = TrainerID
                };
                context.Entry(trainer).State = System.Data.Entity.EntityState.Deleted;

                //context.students.Remove(trainer);
                context.SaveChanges();
            }
            return false;
        }
    }
}
