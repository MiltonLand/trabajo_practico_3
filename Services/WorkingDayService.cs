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
                HoursWorked = c.HoursWorked
            }).Where(c=> c.TimeIn.Day == DateTime.Now.Day)
            .ToList();

            return workingDayDto;
        }

        public void Create(WorkingDayDto workingDayDto)
        {
            var workingDay = this.CreateFromDto(workingDayDto);

            this.AddToDatabase(workingDay);
        }

        public void Update (WorkingDayDto workingDayDto)
        {
            var workigDay = _workingDayRepository.Set().FirstOrDefault(c => c.WorkingDayID == workingDayDto.WorkingDayID);

            if (workigDay == null)
                return;

            workigDay.EmployeeID = workingDayDto.EmployeeID;
            workigDay.TimeIn = workingDayDto.TimeIn;            
            workigDay.TimeOut = workingDayDto.TimeOut;
            workigDay.HoursWorked = workingDayDto.HoursWorked;

            _workingDayRepository.SaveChanges();
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

        internal int GetHoursWorked(int employeeId, int year, int month)
        {
            var workingDays = _workingDayRepository
                              .Set()
                              .Where(w => w.EmployeeID == employeeId && 
                                          w.TimeIn.Year == year &&
                                          w.TimeIn.Month == month);

            int totalHours = 0;

            foreach (var workingDay in workingDays)
            {
                if (workingDay.HoursWorked != null)
                {
                    totalHours += (int)workingDay.HoursWorked;
                }
            }

            return totalHours;
        }
        internal void DeleteAllRelated(int employeeId)
        {
            IList<WorkingDay> workingDays = _workingDayRepository
                                                 .Set()
                                                 .Where(w => w.EmployeeID == employeeId).ToList();

            foreach (var workingDay in workingDays)
            {
                this.DeleteFromDatabase(workingDay);
            }
        }

        private WorkingDay CreateFromDto(WorkingDayDto workingDayDto)
        {
            var workingDay = new WorkingDay();
            workingDay.EmployeeID = workingDayDto.EmployeeID;
            workingDay.TimeIn = workingDayDto.TimeIn;
            workingDay.TimeOut = workingDayDto.TimeOut;
            workingDay.HoursWorked = workingDayDto.HoursWorked;

            return workingDay;
        }
        private WorkingDayDto CreateDto(int workingDayId, int employeeId, DateTime timeIn, DateTime? timeOut, decimal? hoursWorked)
        {
            var workingDayDto = new WorkingDayDto();

            workingDayDto.WorkingDayID = workingDayId;
            workingDayDto.EmployeeID = employeeId;
            workingDayDto.TimeIn = timeIn;
            workingDayDto.TimeOut = timeOut;
            workingDayDto.HoursWorked = hoursWorked;

            return workingDayDto;
        }
        private WorkingDayDto ConvertoToDto(WorkingDay wd)
        {
            return this.CreateDto(wd.WorkingDayID, wd.EmployeeID, 
                                  wd.TimeIn, wd.TimeOut, wd.HoursWorked);
        }
        private void AddToDatabase(WorkingDay workingDay)
        {
            if (workingDay == null)
                return;

            _workingDayRepository.Persist(workingDay);
            _workingDayRepository.SaveChanges();
        }
        private void DeleteFromDatabase(WorkingDay workingDay)
        {
            if (workingDay == null)
                return;

            _workingDayRepository.Remove(workingDay);
            _workingDayRepository.SaveChanges();
        }
    }
}
