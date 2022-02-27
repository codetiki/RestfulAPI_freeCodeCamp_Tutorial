using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Communication
{
    public class SaveForceTypeResponse : BaseResponse
    {
        public ForceType ForceType { get; private set; }

        private SaveForceTypeResponse(bool success, string message, ForceType forceType) : base(success, message)
        {
            ForceType = forceType;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="forceType">Saved forceType.</param>
        /// <returns>Response.</returns>
        public SaveForceTypeResponse(ForceType forceType) : this(true, string.Empty, forceType)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveForceTypeResponse(string message) : this(false, message, null)
        { }
    }
}
