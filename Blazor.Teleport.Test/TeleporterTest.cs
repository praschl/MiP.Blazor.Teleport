using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Blazor.Teleport.Test
{
    [TestClass]
    public class TeleporterTest
    {
        private readonly Teleporter _teleporter = new Teleporter();
        private RenderFragment _testFragment1 = builder => builder.AddContent(0, "Test 1");
        private RenderFragment _testFragment2 = builder => builder.AddContent(1, "Test 2");
        private RenderFragment _testFragment3 = builder => builder.AddContent(2, "Test 3");

        [DataRow(null)]
        [DataRow("")]
        [DataTestMethod]
        public void Beam_throws_when_target_is_null_or_Empty(string toTarget)
        {
            Action beam = () => _teleporter.Beam(toTarget, _testFragment1);

            beam.Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("toTarget");
        }

        [TestMethod]
        public void Beam_raises_event()
        {
            var raised = new List<string>();

            _teleporter.TeleportFinished += raised.Add;

            _teleporter.Beam("one", _testFragment1);
            raised.Should().BeEquivalentTo("one");

            _teleporter.Beam("two", _testFragment1);
            raised.Should().BeEquivalentTo("one", "two");
        }

        [DataRow(null)]
        [DataRow("")]
        [DataTestMethod]
        public void Materialize_throws_when_target_is_null_or_Empty(string atTarget)
        {
            Action beam = () => _teleporter.Materialize(atTarget);

            beam.Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("atTarget");
        }

        [TestMethod]
        public void Materialize_returns_correct_fragment()
        {
            _teleporter.Beam("one", _testFragment1);
            _teleporter.Beam("two", _testFragment2);
            _teleporter.Beam("three", _testFragment3);

            var fragment1 = _teleporter.Materialize("one");
            var fragment2 = _teleporter.Materialize("two");
            var fragment3 = _teleporter.Materialize("three");

            fragment1.Should().BeSameAs(_testFragment1);
            fragment2.Should().BeSameAs(_testFragment2);
            fragment3.Should().BeSameAs(_testFragment3);
        }
    }
}
