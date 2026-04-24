using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseApp.Tests
{
    /// <summary>
    /// Вспомогательный класс для проверки исключений 
    /// </summary>
    public static class AssertEx
    {
        /// <summary>
        /// Проверяет, что метод вызывает ожидаемое исключение
        /// </summary>
        /// <typeparam name="TException">Тип ожидаемого исключения</typeparam>
        /// <param name="action">Действие, которое должно вызвать исключение</param>
        public static void ThrowsException<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                // Ожидаемое исключение-тест пройден
                return;
            }
            catch (Exception ex)
            {
                // Некорректное исключение-тест провален
                Assert.Fail($"Ожидалось исключение {typeof(TException).Name}, но было {ex.GetType().Name}. Сообщение: {ex.Message}");
            }

            // Исключение не было вызвано-тест провален
            Assert.Fail($"Ожидалось исключение {typeof(TException).Name}, но исключение не было вызвано");
        }

        /// <summary>
        /// Проверяет, что метод вызывает ожидаемое исключение и возвращает его для проверки
        /// </summary>
        /// <typeparam name="TException">Тип ожидаемого исключения</typeparam>
        /// <param name="action">Действие, которое должно вызвать исключение</param>
        /// <returns>Перехваченное исключение</returns>
        public static TException ThrowsException<TException>(Action action, string message) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                Assert.Fail($"{message}\nОжидалось исключение {typeof(TException).Name}, но было {ex.GetType().Name}");
            }

            Assert.Fail($"{message}\nОжидалось исключение {typeof(TException).Name}, но исключение не было вызвано");
            return null;
        }
    }
}