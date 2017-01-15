using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileEncryptor.Models
{
    /// <summary>
    /// Properties associated with an encryption routine
    /// </summary>
    public class EncryptionTaskProperty
    {
        /// <summary>
        /// InputType determines how to get the message to be encrypted 
        /// </summary>
        public InputType InputType { get; set; }

        /// <summary>
        /// MessageInputProperty contains the properties associated with fetching input via the appropriate channel
        /// </summary>
        public IMessageInputProperty MessageInputProperty { get; set; }

        /// <summary>
        /// KeyOutputType determines what must happen to the message key 
        /// </summary>
        public KeyOutputType KeyOutputType { get; set; }

        /// <summary>
        /// KeyOutputProperty contains the properties associated with the action to be taken with the passphrase
        /// </summary>
        public IKeyOutputProperty KeyOutputProperty { get; set; }

        public EncryptionTaskProperty(InputType inputType, KeyOutputType outputType, IMessageInputProperty messageInputProperty, IKeyOutputProperty keyOutputProperty)
        {
            this.InputType = inputType;
            this.KeyOutputType = outputType;
            this.MessageInputProperty = messageInputProperty;
            this.KeyOutputProperty = keyOutputProperty;
        }
    }
}
