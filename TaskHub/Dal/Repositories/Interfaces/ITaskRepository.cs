using Dal.Entities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий пользователей
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Создать задачу
    /// </summary>
    /// <param name="title">Название задачи</param>
    /// <param name="createdUtc">Дата и время создания задачи в UTC</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Задача</returns>
    Task<TaskEntity> CreateTaskAsync(string? title, DateTimeOffset createdUtc, Guid? createdByUserId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все задачи
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список задач</returns>
    Task<IReadOnlyCollection<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Задача или null, если задача не найдена</returns>
    Task<TaskEntity?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Установить название задачи
    /// </summary>
    /// <param name="taskId">Идентификатор пользователя</param>
    /// <param name="title">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true, если задача удалена, иначе false</returns>
    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}