using System.ComponentModel.DataAnnotations.Schema;
using CodePace.GetWork.API.contest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.contest.Domain.Model.Entities;

public class WeeklyContest 
{
    private string _title;
    private string _urlImage;
    private DateTime _date;
    private WeeklyContest() { } 

    public WeeklyContest(int contestId,string title, string urlImage, DateTime date)
    {
        ContestId = contestId;
        UpdateTitle(title);
        UpdateUrlImage(urlImage);
        UpdateDate(date);
    }

    public int Id { get; private set; }
    public string Title { get => _title; private set => UpdateTitle(value); }
    public string UrlImage { get => _urlImage; private set => UpdateUrlImage(value); }
    
    
    public int ContestId { get; set; }

    public virtual Contest Contest { get; set; }

    public DateTime Date { get => _date; private set => UpdateDate(value); }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        }

        _title = title;
    }

    public void UpdateUrlImage(string urlImage)
    {
        if (string.IsNullOrEmpty(urlImage))
        {
            throw new ArgumentException("UrlImage cannot be null or empty.", nameof(urlImage));
        }

        _urlImage = urlImage;
    }

    public void UpdateDate(DateTime date)
    {
        if (date == default)
        {
            throw new ArgumentException("Date cannot be default.", nameof(date));
        }

        _date = date;
    }
}