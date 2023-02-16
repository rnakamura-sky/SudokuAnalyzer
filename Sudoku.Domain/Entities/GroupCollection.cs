namespace Sudoku.Domain.Entities
{
    public class GroupCollection
    {

        public IReadOnlyCollection<Group> Groups { get; }

        public GroupCollection(IReadOnlyCollection<Group> groups)
        {
            Groups = groups;
        }
    }
}
