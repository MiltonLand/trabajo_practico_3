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

        public List<WorkingDayDto> GetAllForEmp()
        {
            var workingDayDto = _workingDayRepository.Set().Select(c=> new WorkingDayDto
            {
                WorkingDayID = c.WorkingDayID,
                EmployeeID = c.EmployeeID,
                TimeIn = c.TimeIn,
                TimeOut = c.TimeOut,
                WorkedHours = c.WorkedHours
            }).Where(c=> c.TimeIn.Day == DateTime.Now.Day)
            .ToList();

            return workingDayDto;
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

        //MODIFICATIONSSSSS BY M

        public List<WorkingDayDto> GetAllToday()
        {
            return  _workingDayRepository
                                .Set()
                                .Select(c => new WorkingDayDto
                                {
                                    WorkingDayID = c.WorkingDayID,
                                    EmployeeID = c.EmployeeID,
                                    TimeIn = c.TimeIn,
                                    TimeOut = c.TimeOut,
                                    WorkedHours = c.WorkedHours
                                }).Where(c => c.TimeIn.Day == DateTime.Now.Day)
                                .ToList();
        }

        public List<WorkingDayDto> GetAllForEmployeeInMonth(int employeeId, int year, int month)
        {
            var workingDays = _workingDayRepository
                              .Set()
                              .Where(w => w.EmployeeID == employeeId &&
                                          w.TimeIn.Year == year &&
                                          w.TimeIn.Month == month);

            var workingDaysForEmployee = new List<WorkingDayDto>();

            foreach (var workDay in workingDays)
                workingDaysForEmployee.Add(this.ConvertoToDto(workDay));

            return workingDaysForEmployee;
        }

        public int GetHoursWorked(int employeeId, int year, int month)
        {
            var workingDays = _workingDayRepository
                              .Set()
                              .Where(w => w.EmployeeID == employeeId && 
                                          w.TimeIn.Year == year &&
                                          w.TimeIn.Month == month);

            int totalHours = 0;

            foreach (var workingDay in workingDays)
            {
                if (workingDay.WorkedHours != null)
                {
                    totalHours += (int)workingDay.WorkedHours;
                }
            }

            return totalHours;
        }

        private WorkingDayDto CreateDto(int workingDayId, int EmployeeId, DateTime TimeIn, DateTime? TimeOut, int? WorkedHours)
        {
            var workingDayDto = new WorkingDayDto();

            workingDayDto.WorkingDayID = workingDayId;
            workingDayDto.EmployeeID = EmployeeId;
            workingDayDto.TimeIn = TimeIn;
            workingDayDto.TimeOut = TimeOut;
            workingDayDto.WorkedHours = WorkedHours;

            return workingDayDto;
        }
        private WorkingDayDto ConvertoToDto(WorkingDay wd)
        {
            return this.CreateDto(wd.WorkingDayID, wd.EmployeeID, wd.TimeIn, wd.TimeOut, wd.WorkedHours);
        }
    }
}
