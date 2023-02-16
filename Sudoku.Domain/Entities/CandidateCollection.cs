using Sudoku.Domain.ValueObjects;

namespace Sudoku.Domain.Entities
{
    public sealed class CandidateCollection
    {
    private List<bool> _candidates;

    public IReadOnlyList<bool> Candidates => _candidates.AsReadOnly();

    public CandidateCollection(bool allCandidateValue)
    {
        _candidates = new List<bool>();
        for (int i = 0; i < 9; i++)
        {
            _candidates.Add(allCandidateValue);
        }
    }

    public void Reconcil(CellValue cellValue)
    {
        _candidates[cellValue.GetIndex()] = false;
    }

    public bool IsOnlyOneCandidate()
    {
        var count = _candidates.Where(x => x.Equals(true)).Count();
        return count == 1;
    }

    public CellValue GetCellValue()
    {
        var index = 0;
        foreach (var candidate in _candidates)
        {
            if (candidate)
            {
                return new CellValue(index);
            }
            index++;
        }
        throw new Exception();
    }

    public void Off()
    {
        for (int i = 0; i < _candidates.Count; i++)
        {
            _candidates[i] = false;
        }
    }

    public bool Contains(CellValue cellValue)
    {
        return _candidates[cellValue.GetIndex()];
    }
}
}
