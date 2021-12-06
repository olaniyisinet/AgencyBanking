using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgencyBanking.Models;
using AgencyBanking.Helpers;

namespace AgencyBanking.Controllers
{
    [Route("api/")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AgencyBankingContext _context;

        public QuestionsController(AgencyBankingContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet("GetQuestions")]
        public IActionResult GetQuestions()
        {
            try
            {
                var quests = _context.Questions;

                List<QuestionResponse> Questrespones = new List<QuestionResponse>();

                foreach (var quest in quests)
                {
                    Questrespones.Add(new QuestionResponse
                    {
                        QuestionId = quest.Questionid,
                        Question = quest.Question1,
                        CreatedBy = quest.Createdby,
                        DateCreated = quest.Datecreated,
                    });
                }

                return Ok(new ResponseModel2
                {
                    Data = Questrespones,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),// "200",
                    message = "Questions returned successfully",
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),// "200",
                    message = "Questions return failed",
                });
            }
        }


        // POST: api/UserQas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddUserQuestion")]
        public IActionResult AddUserQuestion(UserQuestions userQas)
        {
            try {
                foreach (var uqa in userQas.qa)
                {
                    if (!UserQaExists(userQas.smid, uqa.questionId))
                    {
                        var userQa = new Userqa()
                        {
                            Userqaid = Guid.NewGuid().ToString(),
                            Userid = userQas.smid,
                            Questionid = uqa.questionId,
                            Answer =  Encryption.Encrypt(uqa.answer)
                        };
                        _context.UserQas.Add(userQa);
                        _context.SaveChanges();
                    }
                }

                if(_context.UserQas.Where(x => x.Userid.Equals(userQas.smid)).Count() >= 3)
                {
                    var customer = _context.CustomerProfiles.Where(x => x.Smid.Equals(userQas.smid)).FirstOrDefault();
                    customer.Questioncompleted = true;

                    _context.Entry(customer).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                return Ok(new ResponseModel2
                {
                    Data = "Successful",
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "User Questions Saved Successfully",
                });
            }
            catch(Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = "Failed",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed . "+ ex.Message,
                });
            }
            }

        // GET: api/UserQas/5
        [HttpPost("GetQuestionByUserId")]
        public IActionResult GetQuestionByUserId(string UserId)
        {
            var userQa = _context.UserQas.Where(x => x.Userid.Equals(UserId)).Include(q => q.Question);

            if (userQa == null)
            {
                return NotFound();
            }

            return Ok(new ResponseModel2
            {
                Data = userQa,
                status = "true",
                code = HttpContext.Response.StatusCode.ToString(),
                message = "Successful",
            });

        }

        
        [HttpPost("VerifyQuestionsByUserID")]
        public IActionResult VerifyQuestionsByUserID(VerifyUserQuestion request)
        {
            var userQa = _context.UserQas.Where(x => x.Userid.Equals(request.UserID) && x.Questionid.Equals(Guid.Parse(request.QuestionID))).FirstOrDefault();

            if (userQa == null)
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed. Question Not Found",
                });
            }
            else if (userQa.Answer != Encryption.Encrypt(request.Answer))
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Incorrect Answer",
                });
            }
            else
            {

                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Successful",
                });
            }

        }

        private bool UserQaExists(string userid, string questionId)
        {
            return _context.UserQas.Any(e => e.Userid == userid && e.Questionid == questionId);
        }



        ////// POST: api/Questions
        ////// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("PostQuestion")]
        //public async Task<ActionResult<Question>> PostQuestion(QuestionResponse question)
        //{

        //    var quest = new Question
        //    {
        //        QuestionId = new Guid(),
        //        Question1 = question.Question,
        //        CreatedBy = question.CreatedBy,
        //        DateCreated = DateTime.UtcNow
        //    };

        //    _context.Questions.Add(quest);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (QuestionExists(question.QuestionId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        //}

     
    }
}
