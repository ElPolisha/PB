using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    public void Send(Message message)
    {
        var whatsapp = new WhatsAppApi();
        whatsapp.Send(message.To, message.Text);
    }
}