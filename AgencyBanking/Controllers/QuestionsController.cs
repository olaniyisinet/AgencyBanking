﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgencyBanking.Models;

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
                        QuestionId = quest.QuestionId,
                        Question = quest.Question1,
                        CreatedBy = quest.CreatedBy,
                        DateCreated = quest.DateCreated,
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
                    if (!UserQaExists(userQas.UserId, uqa.questionId))
                    {
                        var userQa = new UserQa()
                        {
                            UserQaid = Guid.NewGuid(),
                            UserId = userQas.UserId,
                            QuestionId = uqa.questionId,
                            Answer = uqa.answer
                        };
                        _context.UserQas.Add(userQa);
                        _context.SaveChangesAsync();
                    }
                }

                if(_context.UserQas.Where(x => x.UserId.Equals(userQas.UserId)).Count() >= 3)
                {
                    var customer = _context.CustomerProfiles.Where(x => x.Smid.Equals(userQas.UserId)).FirstOrDefault();
                    customer.QuestionCompleted = true;

                    _context.Entry(customer).State = EntityState.Modified;
                    _context.SaveChangesAsync();
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
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed . "+ ex.Message,
                });
            }
            }



        // GET: api/UserQas/5
        [HttpPost("GetQuestionByUserId")]
        public IActionResult GetQuestionByUserId(string UserId)
        {
            var userQa = _context.UserQas.Where(x => x.UserId.Equals(UserId)).Include(q => q.Question);

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

        private bool UserQaExists(string userid, Guid? questionId)
        {
            return _context.UserQas.Any(e => e.UserId == userid && e.QuestionId == questionId);
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
