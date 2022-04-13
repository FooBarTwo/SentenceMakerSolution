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

        [HttpGet("{words}/{pWordTypeNum:int}")]
        public async Task<ActionResult> GetWords(int pWordTypeNum)
        {
            WordType wordType = GetWordType(pWordTypeNum);

            return Ok(await wordRepo.GetWords(wordType));
        }

        private WordType GetWordType(int pWordTypeNum)
        {
            //Noun, Verb, Adjective, Adverb, Pronoun, Preposition, Conjunction, Determiner, Exclamation
            WordType wordType;

            switch (pWordTypeNum)
            {
                case 0:
                    wordType = WordType.Noun;
                    break;
                case 1:
                    wordType = WordType.Verb;
                    break;
                case 2:
                    wordType = WordType.Adjective;
                    break;
                case 3:
                    wordType = WordType.Adverb;
                    break;
                case 4:
                    wordType = WordType.Pronoun;
                    break;
                case 5:
                    wordType = WordType.Preposition;
                    break;
                case 6:
                    wordType = WordType.Conjunction;
                    break;
                case 7:
                    wordType = WordType.Determiner;
                    break;
                case 8:
                    wordType = WordType.Exclamation;
                    break;
                default:
                    wordType = WordType.Noun;
                    break;
            }

            return wordType;
        }
    }
}
