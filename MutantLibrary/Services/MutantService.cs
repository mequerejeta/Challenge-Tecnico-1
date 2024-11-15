using MutantDetection.Services.Interfaces;

namespace MutantDetection.Services
{
    public class MutantService : IMutantService
    {
        public bool IsMutant(string[] dna)
        {
            if (!IsValidDna(dna)) throw new ArgumentException("Invalid DNA input.");
            int dnaLength = dna.Length;
            int sequenceCount = 0;

            for (int i = 0; i < dnaLength; i++)
            {
                for (int j = 0; j < dnaLength; j++)
                {
                    if (CheckDirection(i, j, 0, 1, dna, dnaLength) ||   // Horizontal
                        CheckDirection(i, j, 1, 0, dna, dnaLength) ||   // Vertical
                        CheckDirection(i, j, 1, 1, dna, dnaLength) ||   // Diagonal descendente
                        CheckDirection(i, j, 1, -1, dna, dnaLength))    // Diagonal ascendente
                    {
                        sequenceCount++;
                        if (sequenceCount >= 2) return true; 
                    }
                }
            }
            return false;
        }

        private bool CheckDirection(int row, int col, int rowStep, int colStep, string[] dna, int length)
        {
            char letter = dna[row][col];

            for (int k = 1; k < 4; k++)
            {
                int newRow = row + k * rowStep;
                int newCol = col + k * colStep;
                if (newRow >= length || newCol >= length || newCol < 0 || dna[newRow][newCol] != letter)
                    return false;
            }

            return true;
        }

        private bool IsValidDna(string[] dna)
        {
            if (dna == null || dna.Length == 0) return false;

            int n = dna.Length;
            foreach (string row in dna)
            {
                if (row.Length != n || row.Any(c => !"ATCG".Contains(c)))
                    return false;
            }
            return true;
        }
    }
}
