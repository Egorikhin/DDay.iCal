using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DDay.iCal.DataTypes;
using DDay.iCal.Components;

namespace DDay.iCal.Serialization.iCalendar.Components
{
    public class ParameterSerializer : ISerializable
    {
        #region Private Fields

        private Parameter m_Parameter;
        private ISerializationContext m_SerializationContext;

        #endregion

        #region Constructors

        public ParameterSerializer(Parameter parameter)
        {
            this.m_SerializationContext = DDay.iCal.Serialization.SerializationContext.Default;
            this.m_Parameter = parameter;
        }

        #endregion

        #region ISerializable Members

        public ISerializationContext SerializationContext
        {
            get { return m_SerializationContext; }
            set { m_SerializationContext = value; }
        }

        public string SerializeToString()
        {
            string value = m_Parameter.Name + "=";
            string[] values = new string[m_Parameter.Values.Count];
            m_Parameter.Values.CopyTo(values);

            value += string.Join(",", values);
            return value;
        }

        public void Serialize(Stream stream, Encoding encoding)
        {
            byte[] param = encoding.GetBytes(SerializeToString());
            stream.Write(param, 0, param.Length);
        }

        public iCalObject Deserialize(Stream stream, Encoding encoding, Type iCalendarType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion        
    }
}
