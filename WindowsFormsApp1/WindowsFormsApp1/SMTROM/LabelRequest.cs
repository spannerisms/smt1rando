namespace SMTRandoApp.SMTROM;

/// <summary>
/// Reserves space for a pointer associated with a <see cref="LabelName"/> whose address may not yet be determined.
/// </summary>
/// <param name="Name">Name of the <see cref="LabelName"/> object this request is associated with.</param>
/// <param name="Size">Number of bytes to reserve for this label.</param>
internal record LabelRequest(string Name, byte Size);