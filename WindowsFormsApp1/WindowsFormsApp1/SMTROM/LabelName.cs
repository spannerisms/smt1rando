namespace SMTRandoApp.SMTROM;

/// <summary>
/// Marks a location in ROM with a specific name.
/// </summary>
/// <param name="Name">The name of this label.</param>
/// <param name="IsCritical">If <see langword="true"/>, this label will be saved permanently in a list by the <see cref="ROMWriter"/>.</param>
internal record LabelName(string Name, bool IsCritical = false);
