using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Services.Dtos;

namespace Services
{
    public class WorkingDayService
    {
        private Repository<WorkingDay> _workingDayRepository;

        public WorkingDayService()
        {
            _workingDayRepository = new Repository<WorkingDay>();
        }



        public List<WorkingDayDto> GetHoursWorked(int EmployeeId, int year, int mounth)
        {
            var workingDaysDto = _workingDayRepository.Set()
                                                      .Where(c => c.EmployeeID == EmployeeId && c.TimeIn.Year == year && c.TimeIn.Month == mounth)
                                                      .Select(c => new WorkingDayDto
                                                      {
                                                          EmployeeID = c.EmployeeID,
                                                          TimeIn = c.TimeIn,
                                                          TimeOut = c.TimeOut,
                                                          WorkedHours = c.WorkedHours
                                                      })
                                                      .ToList();

            return workingDaysDto;
        }

        public WorkingDayDto GetWorkingDayById(int? employeeId)
        {
            var workingDay = _workingDayRepository.Set()
                                                  .FirstOrDefault(c => c.EmployeeID == employeeId && c.TimeIn.Day == DateTime.Now.Day);
            

            if(workingDay == null)
            {
                return null;
            }
            else
            {
                var workingDayDto = new WorkingDayDto
                {
                    WorkingDayID = workingDay.WorkingDayID,
                    EmployeeID = workingDay.EmployeeID,
                    TimeIn = workingDay.TimeIn,
                    TimeOut = workingDay.TimeOut,
                    WorkedHours = workingDay.WorkedHours
                };

                return workingDayDto;
            }
        }

        public void Save(WorkingDayDto workingDayP)
        {
            var workingDay = new WorkingDay
            {
                EmployeeID = workingDayP.EmployeeID,
                TimeIn = workingDayP.TimeIn,
                TimeOut = workingDayP.TimeOut,
                WorkedHours = workingDayP.WorkedHours
            };

            _workingDayRepository.Persist(workingDay);
            _workingDayRepository.SaveChanges();

        }

        public void Update (WorkingDayDto workingDayP)
        {
            var workigDay = _workingDayRepository.Set().FirstOrDefault(c => c.WorkingDayID == workingDayP.WorkingDayID);

            workigDay.WorkingDayID = workingDayP.WorkingDayID;
            workigDay.EmployeeID = workingDayP.EmployeeID;
            
            workigDay.TimeOut = workingDayP.TimeOut;
            workigDay.WorkedHours = workingDayP.WorkedHours;

            _workingDayRepository.SaveChanges();
        }
    }
}
