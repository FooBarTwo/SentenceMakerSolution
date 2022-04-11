using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SentenceManagement.Api.Models;
using WordManagement.Models;
using Microsoft.AspNetCore.Http;

namespace SentenceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentencesController: ControllerBase
    {
        private readonly ISentenceMakerRepo sentenceMakerRepo;
        private readonly IWordRepo wordRepo;

        public SentencesController(ISentenceMakerRepo sentenceMakerRepo, IWordRepo wordRepo)
        {
            this.sentenceMakerRepo = sentenceMakerRepo;
            this.wordRepo = wordRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetSentences()
        {
            try
            {
                return Ok(await sentenceMakerRepo.GetSentences());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sentence>> GetSentence(int id)
        {
            try
            {
                var result = await sentenceMakerRepo.GetSentence(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieiving data from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Sentence>> CreateSentence(Sentence sentence)
        {
            try
            {
                if (sentence == null)
                {
                    return BadRequest();
                }

                var createdSentence = await sentenceMakerRepo.AddSentence(sentence);
                return CreatedAtAction(nameof(GetSentence), new { id = createdSentence.SentenceId }, sentence);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieiving data from the database.");
            }
        }

        //[Route("api/words")]
        //[HttpGet]
        //public async Task<ActionResult> GetWords(WordType wordType)
        //{
        //    return Ok(await wordRepo.GetWords(wordType));
        //}
    }
}
