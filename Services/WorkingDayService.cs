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
                                                          WorkedHours = c.HoursWorked
                                                      })
                                                      .ToList();

            return workingDaysDto;
        }


    }
}
