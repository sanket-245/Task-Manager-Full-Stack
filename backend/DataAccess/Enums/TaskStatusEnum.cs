using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Enums
{
    public static class TaskStatusEnum
    {
        public static Guid InProgress = System.Guid.Parse("25de4282-5106-f111-bb66-0c96e6b092b6");
        public static Guid Completed = System.Guid.Parse("25de4282-5106-f111-bb66-0c96e6b092b6");
        public static Guid NotStarted = System.Guid.Parse("25de4282-5106-f111-bb66-0c96e6b092b6");


    }
}
