using System;
using Flip;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace ContactList.Tests
{
    public class ContactEditorViewModelTest
    {
        [Theory, AutoData]
        public void SaveCommandEmitsNewModelRevision(ContactEditorViewModel sut)
        {
            Contact next = null;
            Stream<Contact, int>
                .Connect(sut.Model.Id)
                .Subscribe(x => next = x);

            sut.SaveCommand.Execute(null);

            next.Should().NotBeNull();
            next.Name.Should().Be(sut.EditName);
            next.Email.Should().Be(sut.EditEmail);
        }
    }
}
