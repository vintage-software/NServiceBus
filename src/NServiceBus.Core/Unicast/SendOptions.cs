namespace NServiceBus.Unicast
{
    using System;

    /// <summary>
    /// Controls how a message will be sent by the transport
    /// </summary>
    public class SendOptions : DeliveryOptions
    {
        TimeSpan? delayDeliveryWith;

        /// <summary>
        /// Creates an instance of <see cref="SendOptions"/>.
        /// </summary>
        /// <param name="destination">Address where to send this message</param>
        public SendOptions(Address destination)
        {
            Destination = destination;
        }

        /// <summary>
        /// Creates an instance of <see cref="SendOptions"/>.
        /// </summary>
        /// <param name="destination">Address where to send this message</param>
        public SendOptions(string destination)
            : this(Address.Parse(destination))
        {
        }

        /// <summary>
        /// The correlation id to be used on the message. Mostly used when doing Bus.Reply
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// The time when the message should be delivered to the destination
        /// </summary>
        public DateTime? DeliverAt { get; set; }


        /// <summary>
        /// How long to delay delivery of the message
        /// </summary>
        public TimeSpan? DelayDeliveryWith
        {
            get { return delayDeliveryWith; }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new Exception("timespan cannot be less than zero");
                }
                delayDeliveryWith = value;
            }
        }

        /// <summary>
        /// Address where to send this message
        /// </summary>
        public Address Destination { get; set; }

        /// <summary>
        /// The TTR to use for this message
        /// </summary>
        public TimeSpan? TimeToBeReceived { get; set; }
    }
}