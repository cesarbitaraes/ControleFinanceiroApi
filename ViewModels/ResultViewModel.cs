﻿namespace ControleFinanceiroApi.ViewModels;

public class ResultViewModel<T>
{
    public T? Data { get; private set; }
    private List<string> Errors { get; set; } = new();

    public ResultViewModel(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(T data)
    {
        Data = data;
    }

    public ResultViewModel(List<string> errors)
    {
        Errors = errors;
    }

    public ResultViewModel(string error)
    {
        Errors.Add(error);
    }
}