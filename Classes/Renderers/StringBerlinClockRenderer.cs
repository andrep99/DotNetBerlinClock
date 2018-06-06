using System;
using System.Text;

namespace BerlinClock.Classes.Renderers
{
    class StringBerlinClockRenderer : IBerlinClockRenderer<string>
    {
        private readonly LightRepresentations _lightRepresentation;

        public StringBerlinClockRenderer()
        {
            _lightRepresentation = new LightRepresentations();
        }

        public StringBerlinClockRenderer(LightRepresentations lightRepresentation)
        {
            _lightRepresentation = lightRepresentation;
        }

        public string RenderBerlinClock(BerlinClockData berlinClockData)
        {
            if (!berlinClockData.IsValid()) throw new ArgumentException("Data for rendering are not valid");
            BerlinClockLightRowsRenditions rowsRenditions = ConstructRowsFromData(berlinClockData);
            StringBuilder representationResult = ConcatRows(rowsRenditions);
            return representationResult.ToString();
        }



        private BerlinClockLightRowsRenditions ConstructRowsFromData(BerlinClockData berlinClockData)
        {
            var rows = new BerlinClockLightRowsRenditions();
            rows.FirstRow = berlinClockData.IsOneSecondLightActive ? _lightRepresentation.YellowLight.ToString() : 
                                                                      _lightRepresentation.Off.ToString();
            rows.SecondRow = CreateLightRow(numberOfActiveLights: berlinClockData.FiveHoursLightsCount,
                                           maxNumberOfLights: BerlinClockDefinition.MaxNumberOfFiveHoursLights,
                                           activeLightRepresentation: _lightRepresentation.RedLight);
            rows.ThirdRow = CreateLightRow(numberOfActiveLights: berlinClockData.OneHourLightsCount,
                                          maxNumberOfLights: BerlinClockDefinition.MaxNumberOfOneHourLights,
                                          activeLightRepresentation: _lightRepresentation.RedLight);
            var tmpFourthRow = CreateLightRow(numberOfActiveLights: berlinClockData.FiveMinutesLightsCount,
                                           maxNumberOfLights: BerlinClockDefinition.MaxNumberOfFiveMinutesLights,
                                           activeLightRepresentation: _lightRepresentation.YellowLight);
            rows.FourthRow = MarkQuarters(aRow: tmpFourthRow, 
                                          activeLightRepresentation: _lightRepresentation.YellowLight, 
                                          quaterLightRepresentation: _lightRepresentation.RedLight);
            rows.FifthRow = CreateLightRow(numberOfActiveLights: berlinClockData.OneMinuteLightsCount,
                                          maxNumberOfLights: BerlinClockDefinition.MaxNumberOfOneMinuteLights,
                                          activeLightRepresentation: _lightRepresentation.YellowLight);
            return rows;
        }

        private static StringBuilder ConcatRows(BerlinClockLightRowsRenditions rowsRenditions)
        {
            const int charsInRepresentation = 40;
            var representationResult = new StringBuilder(charsInRepresentation);
            representationResult.AppendLine(rowsRenditions.FirstRow);
            representationResult.AppendLine(rowsRenditions.SecondRow);
            representationResult.AppendLine(rowsRenditions.ThirdRow);
            representationResult.AppendLine(rowsRenditions.FourthRow);
            representationResult.Append(rowsRenditions.FifthRow);
            return representationResult;
        }

        private string MarkQuarters(string aRow, char activeLightRepresentation, char quaterLightRepresentation)
        {
            var rowCharArray = aRow.ToCharArray();
            foreach (var indexOfQuarter in BerlinClockDefinition.IndecesOfQuarters)
            {
                var shouldLightIndicateQuarter = rowCharArray[indexOfQuarter] == activeLightRepresentation;
                if (shouldLightIndicateQuarter)
                {
                    rowCharArray[indexOfQuarter] = quaterLightRepresentation;
                }
            }

            return new string(rowCharArray);
        }

        private string CreateLightRow(int numberOfActiveLights, int maxNumberOfLights, char activeLightRepresentation)
        {
            return new string(activeLightRepresentation, numberOfActiveLights) +
                   new string(_lightRepresentation.Off, maxNumberOfLights - numberOfActiveLights);
        }
    }

    public class LightRepresentations
    {
        public char YellowLight { get; set; } = 'Y';
        public char RedLight { get; set; } = 'R';
        public char Off { get; set; } = 'O';

    }

    class BerlinClockLightRowsRenditions
    {
        public string FirstRow { get; set; }
        public string SecondRow { get; set; }
        public string ThirdRow { get; set; }
        public string FourthRow { get; set; }
        public string FifthRow { get; set; }
    }
}
