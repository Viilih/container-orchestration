namespace Storage.DTOs;

public record AddImageDto(Guid ProductId, IFormFile ImageFile);