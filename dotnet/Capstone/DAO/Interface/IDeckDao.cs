﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interface
{
    public interface IDeckDao
    {
        List<Deck> GetDecks();

    }
}
