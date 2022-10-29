using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonkDigitalLab.Interfaces;
using MonkDigitalLab.Models.Entities;
using MonkDigitalLab.Models.Request;
using MonkDigitalLab.Models.Responce;
using MonkDigitalLab.Utilities;

namespace MonkDigitalLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailsController : ControllerBase
    {
        private readonly ILogger<MailsController> _logger;
        private IMailSenderService _mailSenderService;
        private IMailStoreService _mailStoreService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="mailSenderService">Сервис отправки писем</param>
        /// <param name="mailService">Сервис писем</param>
        public MailsController(ILogger<MailsController> logger, 
            IMailSenderService mailSenderService, 
            IMailStoreService mailStoreService)
        {
            _logger = logger;
            _mailSenderService = mailSenderService;
            _mailStoreService = mailStoreService;
        }

        /// <summary>
        /// Получение писем
        /// </summary>
        /// <returns>Коллекция писем</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMailsResponce>>> Get()
        {
            try
            {
                var foundMails = await _mailStoreService.GetMailsAsync();
                var result = new List<GetMailsResponce>();

                foreach (var mail in foundMails) {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Mail, GetMailsResponce>();
                        cfg.CreateMap<string, IEnumerable<string>>().ConvertUsing(new StringToArrayTypeConverter());
                    });
                    var mapper = config.CreateMapper();
                    result.Add(mapper.Map<GetMailsResponce>(mail));
                }                  

                return Ok(result);
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);

                return BadRequest();
            }
        }

        /// <summary>
        /// Отправка письма
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(PostMailRequest request)
        {
            try
            {
                var config = new MapperConfiguration(cfg => { 
                    cfg.CreateMap<PostMailRequest, Mail>();
                    cfg.CreateMap<IEnumerable<string>, string>().ConvertUsing(new ArrayToStringTypeConverter());
                });
                var mapper = config.CreateMapper();
                var mail = mapper.Map<Mail>(request);                

                var sendResult = await _mailSenderService.SendEmailAsync(mail, request.Recipients);
                await _mailStoreService.AddMailAsync(sendResult);

                return Ok();
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);

                return BadRequest();
            }
        }
    }
}