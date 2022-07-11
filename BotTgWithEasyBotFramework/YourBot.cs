using BotTgWithEasyBotFramework;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace YourEasyBot
{
    internal class YourBot : EasyBot
    {
        static void Main(string[] args)
        {
            var bot = new YourBot(args[0]);
            bot.Run();
        }

        public YourBot(string botToken) : base(botToken) { }

        public override async Task OnPrivateChat(Chat chat, User user, UpdateInfo update)
        {
            if (update.UpdateKind != UpdateKind.NewMessage || update.MsgCategory != MsgCategory.Text)
                return;
            if (update.Message.Text == "/start")
            {
                #region comments
                //await Telegram.SendTextMessageAsync(chat, "What is your first name?");
                //var firstName = await NewTextMessage(update);
                //// execution continues here once we received a new text message
                //await Telegram.SendTextMessageAsync(chat, "What is your last name?");
                //var lastName = await NewTextMessage(update);
                //var genderMsg = await Telegram.SendTextMessageAsync(chat, "What is your gender?", replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton[]
                //{
                //	new InlineKeyboardButton("Male") { CallbackData = "🚹" }, new InlineKeyboardButton("Female") { CallbackData = "🚺" }, new InlineKeyboardButton("Other") { CallbackData = "⚧" }
                //}));
                //var genderEmoji = await ButtonClicked(update, genderMsg);
                //ReplyCallback(update, "You clicked " + genderEmoji);
                //await Telegram.SendTextMessageAsync(chat, $"Welcome, {firstName} {lastName}! ({genderEmoji})" +
                //	$"\n\nFor more fun, try to type /button@{BotName} in a group I'm in");
                //return;
                #endregion

                await Telegram.SendTextMessageAsync(chat, "Добро пожаловать в наш бот!", replyMarkup: Buttons.GetKeyboardButtons());

            }

            if (update.Message.Text == "О нас 🧑🏻‍💻")
            {
                await Telegram.SendTextMessageAsync(chat, "Чиними-переустанавливаем\n  \n Честно \n  \n Быстро \n  \n Недорого!");
                return;
            }

            if (update.Message.Text == "Контакты ☎️")
            {
                await Telegram.SendTextMessageAsync(chat, "Воспользуйте удобным для вас способом:\n  \n +1111111111111 \n  \n +1111111111111",
                    replyMarkup: Buttons.GetInlineKeyboardContacts());
                return;
            }

            if (update.Message.Text == "Наш прайс 📋")
            {
                await Telegram.SendTextMessageAsync(chat, "Всё по 300!");
                return;
            }

            if (update.Message.Text == "Оставьте заявку ✅")
            {
                await Telegram.SendTextMessageAsync(chat, "Оставьте свой номер телефона и мы вам совсем скоро перезвоним:");

                var numberPhone = await NewTextMessage(update);

                if (numberPhone != "/start" &
                numberPhone != "О нас 🧑🏻‍💻" &
                numberPhone != "Контакты ☎️" &
                numberPhone != "Наш прайс 📋" &
                numberPhone != "Оставьте заявку ✅")
                {
                    await Telegram.CopyMessageAsync(-1001636182201, update.Message.From.Id, update.Message.MessageId);
                    await Telegram.SendTextMessageAsync(chat, $"Спасибо! Скоро мы с вами свяжемся. {numberPhone}");
                    return;
                }
                return;
            }


            #region old logic
            //if (update.Message.Text == "О нас 🧑🏻‍💻")
            //{
            //    await Telegram.SendTextMessageAsync(chat, "Чиними-переустанавливаем\n  \n Честно \n  \n Быстро \n  \n Недорого!");
            //    return;
            //}

            //         if (update.Message.Text == "Контакты ☎️")
            //{
            //	await Telegram.SendTextMessageAsync(chat, "Воспользуйте удобным для вас способом:\n  \n +1111111111111 \n  \n +1111111111111",
            //		replyMarkup: Buttons.GetInlineKeyboardContacts());
            //	return;
            //}

            //if (update.Message.Text == "Наш прайс 📋")
            //{
            //	await Telegram.SendTextMessageAsync(chat, "Всё по 300!");
            //	return;
            //}

            //if (update.Message.Text == "Оставьте заявку ✅")
            //{
            //	await Telegram.SendTextMessageAsync(chat, "Оставьте свой номер телефона и мы вам совсем скоро перезвоним:");


            //	if (update.Message.Text != "/start" &
            //	update.Message.Text != "О нас 🧑🏻‍💻" &
            //	update.Message.Text != "Контакты ☎️" &
            //	update.Message.Text != "Наш прайс 📋" &
            //	update.Message.Text != "Оставьте заявку ✅")
            //	{
            //		await Telegram.CopyMessageAsync(-1001636182201, 897914027, update.Message.MessageId);
            //		await Telegram.SendTextMessageAsync(chat, "Спасибо! Скоро мы с вами свяжемся.");
            //		return;
            //	}
            //}
            #endregion
        }

        //public override async Task OnGroupChat(Chat chat, UpdateInfo update)
        //{
        //	Console.WriteLine($"In group chat {chat.Name()}");
        //	do
        //	{
        //		switch (update.UpdateKind)
        //		{
        //			case UpdateKind.NewMessage:
        //				Console.WriteLine($"{update.Message.From.Name()} wrote: {update.Message.Text}");
        //				if (update.Message.Text == "/button@" + BotName)
        //					await Telegram.SendTextMessageAsync(chat, "You summoned me!", replyMarkup: new InlineKeyboardMarkup("I grant your wish"));
        //				break;
        //			case UpdateKind.EditedMessage:
        //				Console.WriteLine($"{update.Message.From.Name()} edited: {update.Message.Text}");
        //				break;
        //			case UpdateKind.CallbackQuery:
        //				Console.WriteLine($"{update.Message.From.Name()} clicked the button with data '{update.CallbackData}' on the msg: {update.Message.Text}");
        //				ReplyCallback(update, "Wish granted !");
        //				break;
        //		}
        //		// in this approach, we choose to continue execution in a loop, obtaining new updates/messages for this chat as they come
        //	} while (await NextEvent(update) != 0);
        //}

        
    }
}
